﻿/*
    This file is part of BabBot.

    BabBot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    BabBot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with BabBot.  If not, see <http://www.gnu.org/licenses/>.

    Copyright 2009 BabBot Team
*/
using System;

namespace BabBot.States
{
    public sealed class StateMachine<T>
    {
        /// <summary>
        /// Delegate method to update bot state
        /// </summary>
        /// <param name="new_status">New bot status</param>
        /// <param name="queue">Current queue</param>
        public delegate void StateChangeDelegate(string new_status, string queue);

        /// <summary>Create a new state machine for the given entity.</summary>
        /// <param name="Entity">The entity that this state machine belongs too</param>
        public StateMachine(T Entity)
        {
            //make sure entity is not null, if null then throw an exception
            if (Entity == null)
            {
                throw new NullReferenceException("Entity must not be null.");
            }

            //Capture Entity
            this.Entity = Entity;

            //set states to nulls
            GlobalState = null;
            CurrentState = null;
        }

        /// <summary>The object that owns this finite state engine</summary>
        public T Entity { get; private set; }

        /// <summary>
        /// State change event
        /// </summary>
        public event StateChangeDelegate StateChangedEvent;

        /// <summary>
        /// The overal "goal" state (what this state machine is ultimately trying to accomplish.
        /// This will also manage what the current state is by changing states as needed
        /// </summary>
        /// <remarks>
        /// ie: Level up, fish, farm, w/e
        ///</remarks>
        public State<T> GlobalState { get; private set; }

        /// <summary>The currently active state for this state machine.</summary>
        /// <remarks>This will be set by the global state (most of the time).</remarks>
        public State<T> CurrentState { get; private set; }

        /// <summary>Date/Time when last update was executed</summary>
        public DateTime LastUpdated { get; private set; }

        private bool _running;

        /// <summary>Set, Get the state machine running state</summary>
        public bool IsRunning
        {
            get { return _running; }
            set
            {
                _running = value;
                if (!_running)
                {
                    GlobalState = null;
                    CurrentState = null;
                    OnStateChangedUnknown();
                }
            }
        }

        private object obj = new object();
        private State<T> _init_state;

        /// <summary>
        /// Initial Global State
        /// This parameter must be used to initialize StateMachine
        /// if initialization happened outside of BotManager thread
        /// </summary>
        public State<T> InitState
        {
            get
            {
                lock (obj)
                {
                    return _init_state;
                }
            }
            set
            {
                lock (obj)
                {
                    _init_state = value;
                }
            }
        }

        public void SetGlobalState(State<T> NewGlobalState)
        {
            //if a global state currently exists then exit i
            if (GlobalState != null)
            {
                GlobalState.Exit(Entity);
                //remove change state request from old global
                GlobalState.ChangeStateRequest -= CurrentState_ChangeStateRequest;
            }

            //set new global state
            GlobalState = NewGlobalState;

            // Update GUI
            OnGlobalStateChanged(GlobalState);

            //connect up to the global states change state request
            GlobalState.ChangeStateRequest += CurrentState_ChangeStateRequest;

            //enter new global state
            GlobalState.Enter(Entity);
        }

        /// <summary>Update states in state machine</summary>
        public void Update()
        {
            //if state machine is not active, then skip
            if (!_running)
            {
                // Initialize and start state machine
                // If global state assigned by external thread
                if (InitState != null)
                {
                    SetGlobalState(InitState);
                    InitState = null;

                    _running = true;
                } else
                    return;
            }

            //update the global state (if it exists and has not already exited or finished)
            if (GlobalState != null) 
            {
                if (GlobalState.Started)
                {
                    GlobalState.Execute(Entity);
                }
                else if (GlobalState.Completed)
                {
                    // Global state doesn't have track
                    // So if it completed stop state machine as well
                    _running = false;
                }
            }

            //update the current state (if it exists and has not already exited or finished)
            if (CurrentState != null)
            {
                if (CurrentState.Started)
                {
                    CurrentState.Execute(Entity);
                }
                else if (CurrentState.Completed)
                {
                    // if current state has track of previous state
                    // than auto-revert, otherwise set it null
                    if (CurrentState.PreviousState != null)
                    {
                        RevertToPreviousState();
                    }
                    else
                    {
                        CurrentState = null;
                        OnStateChangedUnknown();
                    }
                }
            }

            //update last updated variable
            LastUpdated = DateTime.Now;
        }

        /// <summary>
        /// Safe change state. Track previous and don't exit current.
        /// </summary>
        /// <param name="NewState">New State</param>
        public void SafeStateChange(State<T> NewState)
        {
            ChangeState(NewState, true, false);
        }

        /// <summary>
        /// Change the current state to the new specified state.
        /// </summary>
        /// <param name="NewState">New State</param>
        /// <param name="TrackPrevious">Track and Return to current state</param>
        /// <param name="ExitPrevious">Exit current state or keep it pending</param>
        public void ChangeState(State<T> NewState, bool TrackPrevious, bool ExitPrevious)
        {
            //if a current state exists, and we need to keep track
            // of the current state so we can go back to it later
            if (CurrentState != null && TrackPrevious)
            {
                //Capture current state as previous state
                NewState.PreviousState = CurrentState;
            }
            else
            {
                //if we aren't going to track this one anymore
                // then remove the state change request event
                if (CurrentState != null)
                    CurrentState.ChangeStateRequest -= CurrentState_ChangeStateRequest;
            }

            //if we need to exit the previous state 
            // then do so.
            if (ExitPrevious && CurrentState != null)
            {
                //Exit Current State
                CurrentState.Exit(Entity);
            }

            //capture new current state
            CurrentState = NewState;

            // Update GUI
            OnStateChanged(CurrentState);

            //hook up to the new states "State Change Request" event
            // if it is not already hooked up
            if (!CurrentState.HasChangeStateEventHookup)
            {
                CurrentState.ChangeStateRequest +=
                    CurrentState_ChangeStateRequest;
            }

            //Enter new state if enter date/time is min date
            // otherwise we entered before and we don't need to enter again
            // OR re-enter if the exit time is not min value
            if (!CurrentState.Started)
            {
                CurrentState.Enter(Entity);
            }
        }

        /// <summary>Change back to the previous state</summary>
        public void RevertToPreviousState()
        {
            //when going back to a previous state we want to 
            // not track the current state
            // exit previous state depends of current state status
            bool exit = !CurrentState.Completed;
            ChangeState(CurrentState.PreviousState, false, exit);
        }

        private void CurrentState_ChangeStateRequest(object sender, ChangeStateEventArgs<T> e)
        {
            //when the currently running state requests a change request (either the global or CurrentState).
            // then pause currently running state and switch to the new one.
            ChangeState(e.NewState, e.TrackPrevious, e.ExitPrevious);
        }

        /// <summary>Is state machine in the specified state?</summary>
        public bool IsInState(Type State)
        {
            return (CurrentState != null &&
                CurrentState.GetType() == State && 
                    CurrentState.ExitTime == DateTime.MinValue);
        }

        /// <summary>
        /// Send update event to GUI when global state changed
        /// </summary>
        /// <param name="state">New state</param>
        /// <param name="global">Is State Global</param>
        private void OnGlobalStateChanged(State<T> state)
        {
            OnStateChanged(null, state, true);
        }

        /// <summary>
        /// Send update event to GUI when global state changed
        /// </summary>
        /// <param name="state">New state</param>
        /// <param name="global">Is State Global</param>
        private void OnStateChanged(State<T> state)
        {
            OnStateChanged("", state, false);
        }

        /// <summary>
        /// Send update event to GUI when global or local state changed
        /// </summary>
        /// <param name="state">Update text</param>
        /// <param name="global">Is State Global</param>
        private void OnStateChanged(string state_str, State<T> state, bool global)
        {
            if (StateChangedEvent == null)
                return;

            string queue = "";
            if (!global)
            {
                State<T> prev_state = state.PreviousState;
                while (prev_state != null)
                {
                    queue += prev_state.Name + Environment.NewLine;
                    prev_state = prev_state.PreviousState;
                }

                // Last always global state
                queue += GlobalState.Name;
            }

            StateChangedEvent(state_str, queue);

            if (string.IsNullOrEmpty(state_str))
                // Make state from class name
                state_str = state.Name;

            StateChangedEvent(state_str, queue);
        }

        private void OnStateChangedUnknown()
        {
            if (StateChangedEvent != null)
                StateChangedEvent("UNKNOWN", "");
        }
    }
}