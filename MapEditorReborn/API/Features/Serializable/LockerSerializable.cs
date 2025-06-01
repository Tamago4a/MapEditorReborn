// -----------------------------------------------------------------------
// <copyright file="LockerSerializable.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace MapEditorReborn.API.Features.Serializable
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using global::MapEditorReborn.Interfaces;
    using Interactables.Interobjects.DoorUtils;
    using System;
    using System.Collections.Generic;
    using Utf8Json;
    using static API;
    using LockerType = Enums.LockerType;

    public class LockerSerializable : SerializableObject, ISpawnManager
    {
        public LockerSerializable()
        {
        }

        public LockerSerializable(SchematicBlockData block)
        {
            LockerType = (LockerType)Enum.Parse(typeof(LockerType), block.Properties["LockerType"].ToString());
            Chambers = JsonSerializer.Deserialize<Dictionary<int, List<LockerItemSerializable>>>(JsonSerializer.Serialize(block.Properties["Chambers"]));
            AllowedRoleTypes = JsonSerializer.Deserialize<List<string>>(JsonSerializer.Serialize(block.Properties["AllowedRoleTypes"]));
            ShuffleChambers = bool.Parse(block.Properties["ShuffleChambers"].ToString());
            KeycardPermissions = (DoorPermissionFlags)Enum.Parse(typeof(DoorPermissionFlags), block.Properties["KeycardPermissions"].ToString());
            OpenedChambers = ushort.Parse(block.Properties["OpenedChambers"].ToString());
            InteractLock = bool.Parse(block.Properties["InteractLock"].ToString());
            Chance = float.Parse(block.Properties["Chance"].ToString());
        }

        public LockerType LockerType { get; set; }

        public Dictionary<int, List<LockerItemSerializable>> Chambers { get; set; } = new()
        {
            { 0, new () { new () } },
        };

        public List<string> AllowedRoleTypes { get; set; } = new()
        {
            "Scp0492",
            "Scp049",
            "Scp096",
            "Scp106",
            "Scp173",
            "Scp93953",
            "Scp93989",
            "ClassD",
            "Scientist",
            "FacilityGuard",
            "NtfPrivate",
            "NtfSergeant",
            "NtfSpecialist",
            "NtfCaptain",
            "ChaosConscript",
            "ChaosRifleman",
            "ChaosRepressor",
            "ChaosMarauder",
            "Tutorial",
        };

        public bool ShuffleChambers { get; set; } = true;

        public DoorPermissionFlags KeycardPermissions { get; set; } = DoorPermissionFlags.None;

        public ushort OpenedChambers { get; set; }

        public bool InteractLock { get; set; }

        public float Chance { get; set; } = 100f;

        public void TryAddSpawnObject()
        {
            Log.Debug($"Trying to spawn a locker at {this.Position}.");
            if (!MapUtils.IsRoomExist(this.RoomType)) return;
            SpawnedObjects.Add(ObjectSpawner.SpawnLocker(this));
        }
    }
}
