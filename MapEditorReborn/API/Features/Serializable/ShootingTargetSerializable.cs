// -----------------------------------------------------------------------
// <copyright file="ShootingTargetSerializable.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace MapEditorReborn.API.Features.Serializable
{
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using global::MapEditorReborn.Interfaces;
    using System;
    using static API;

    /// <summary>
    /// A tool used to spawn and save ShootingTargets to a file.
    /// </summary>
    [Serializable]
    public class ShootingTargetSerializable : SerializableObject, ISpawnManager
    {
        /// <summary>
        /// Gets or sets the <see cref="ShootingTargetSerializable"/>'s <see cref="ShootingTargetType"/>.
        /// </summary>
        public ShootingTargetType TargetType { get; set; } = ShootingTargetType.Sport;

        /// <summary>
        /// Gets or sets a value indicating whether shooting target is functional.
        /// <para>Example: plays CASSIE on shot.</para>
        /// </summary>
        public bool IsFunctional { get; set; } = true;

        public void TryAddSpawnObject()
        {
            Log.Debug($"Trying to spawn a shooting target at {this.RoomType}.");
            if (!MapUtils.IsRoomExist(this.RoomType)) return;
            SpawnedObjects.Add(ObjectSpawner.SpawnShootingTarget(this));
        }
    }
}
