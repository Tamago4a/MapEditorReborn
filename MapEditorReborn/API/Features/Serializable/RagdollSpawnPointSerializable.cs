// -----------------------------------------------------------------------
// <copyright file="RagdollSpawnPointSerializable.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace MapEditorReborn.API.Features.Serializable
{
    using Exiled.API.Features;
    using global::MapEditorReborn.Interfaces;
    using PlayerRoles;
    using System;
    using UnityEngine;
    using YamlDotNet.Serialization;
    using static API;

    /// <summary>
    /// A tool to spawn and save RagdollSpawnPoints to a file.
    /// </summary>
    [Serializable]
    public class RagdollSpawnPointSerializable : SerializableObject, ISpawnManager
    {
        /// <summary>
        /// Gets or sets the name of the ragdoll to spawned.
        /// <para>If this is empty, a random name will be choosen from <see cref="MapSchematic.RagdollRoleNames"/>.</para>
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the RoleType of the ragdoll to spawn.
        /// </summary>
        public RoleTypeId RoleType { get; set; } = RoleTypeId.ClassD;

        /// <summary>
        /// Gets or sets the death reason of the ragdoll to spawn.
        /// </summary>
        public string DeathReason { get; set; } = "None";

        /// <summary>
        /// Gets or sets the spawn chance of the ragdoll.
        /// </summary>
        public int SpawnChance { get; set; } = 100;

        [YamlIgnore]
        public override Vector3 Scale { get; set; }

        public void TryAddSpawnObject()
        {
            Log.Debug($"Trying to spawn a ragdoll spawn point at {this.RoomType}.");
            if (!MapUtils.IsRoomExist(this.RoomType)) return;
            SpawnedObjects.Add(ObjectSpawner.SpawnRagdollSpawnPoint(this));
        }
    }
}
