// -----------------------------------------------------------------------
// <copyright file="RoomLightSerializable.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace MapEditorReborn.API.Features.Serializable
{
    using Exiled.API.Features;
    using global::MapEditorReborn.Interfaces;
    using System;
    using UnityEngine;
    using YamlDotNet.Serialization;
    using static API;

    /// <summary>
    /// A tool used to spawn and save LightControllers to a file.
    /// </summary>
    [Serializable]
    public class RoomLightSerializable : SerializableObject, ISpawnManager
    {
        /// <summary>
        /// Gets or sets the <see cref="RoomLightSerializable"/>'s color.
        /// </summary>
        public string Color { get; set; } = "red";

        /// <summary>
        /// Gets or sets the <see cref="RoomLightSerializable"/>'s color shift speed.
        /// <para>If set to 0, the light won't shift at all (static light).</para>
        /// </summary>
        public float ShiftSpeed { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="RoomLightSerializable"/> should only work.
        /// <para>This applies when the Alpha Warhead is activated only.</para>
        /// </summary>
        public bool OnlyWarheadLight { get; set; } = false;

        [YamlIgnore]
        public override Vector3 Position { get; set; }

        [YamlIgnore]
        public override Vector3 Rotation { get; set; }

        [YamlIgnore]
        public override Vector3 Scale { get; set; }

        public void TryAddSpawnObject()
        {
            Log.Debug($"Trying to spawn a room light controller at {this.RoomType}.");
            if (!MapUtils.IsRoomExist(this.RoomType)) return;
            SpawnedObjects.Add(ObjectSpawner.SpawnRoomLight(this));
        }
    }
}
