// -----------------------------------------------------------------------
// <copyright file="PlayerSpawnPointSerializable.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace MapEditorReborn.API.Features.Serializable
{
    using Enums;
    using Exiled.API.Features;
    using global::MapEditorReborn.Interfaces;
    using System;
    using UnityEngine;
    using YamlDotNet.Serialization;
    using static API;

    /// <summary>
    /// A tool used to spawn and save PlayerSpawnPoints to a file.
    /// </summary>
    [Serializable]
    public class PlayerSpawnPointSerializable : SerializableObject, ISpawnManager
    {
        /// <summary>
        /// Gets or sets the <see cref="PlayerSpawnPointSerializable"/>'s <see cref="Enums.SpawnableTeam"/>.
        /// </summary>
        public SpawnableTeam SpawnableTeam { get; set; }

        [YamlIgnore]
        public override Vector3 Rotation { get; set; }

        [YamlIgnore]
        public override Vector3 Scale { get; set; }

        public void TryAddSpawnObject()
        {
            Log.Debug($"Trying to spawn a player spawn point at {this.RoomType}.");
            if (!MapUtils.IsRoomExist(this.RoomType)) return;
            SpawnedObjects.Add(ObjectSpawner.SpawnPlayerSpawnPoint(this));
        }
    }
}
