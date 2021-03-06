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
using System.Collections.Generic;
using System.Text;
using BabBot.Manager;

namespace BabBot.Wow
{
    public class WowGameObject : WowObject
    {
        public WowGameObject(uint ObjectPointer)
            : base(ObjectPointer)
        {

        }

        public override string Name
        {
            get
            {
                return ProcessManager.WowProcess.ReadASCIIString(
                    ProcessManager.WowProcess.ReadUInt(
                    ProcessManager.WowProcess.ReadUInt(ObjectPointer + 
                        DataManager.CurWoWVersion.Globals.GameObjNameBaseOffset1) +
                        DataManager.CurWoWVersion.Globals.GameObjNameBaseOffset2),
                        DataManager.CurWoWVersion.Globals.GameObjNameLen);
            }
        }
    }
}
