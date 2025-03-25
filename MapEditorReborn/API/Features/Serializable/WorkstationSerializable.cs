// -----------------------------------------------------------------------
// <copyright file="WorkstationSerializable.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace MapEditorReborn.API.Features.Serializable
{
    using Exiled.API.Features;
    using global::MapEditorReborn.Interfaces;
    using System;
    using static API;

    /// <summary>
    /// A tool used to spawn and save Workstations to a file.
    /// </summary>
    [Serializable]
    public class WorkstationSerializable : SerializableObject, ISpawnManager
    {
        public WorkstationSerializable()
        {
        }

        public WorkstationSerializable(bool isInteractable)
        {
            IsInteractable = isInteractable;
        }

        public WorkstationSerializable(SchematicBlockData block)
        {
            IsInteractable = block.Properties.ContainsKey("IsInteractable");
        }

        /// <summary>
        /// Gets or sets a value indicating whether the player can interact with the <see cref="WorkstationSerializable"/>.
        /// </summary>
        public bool IsInteractable { get; set; } = true;

        public void TryAddSpawnObject()
        {
            Log.Debug($"Trying to spawn a workstation at {this.RoomType}.");
            if (!MapUtils.IsRoomExist(this.RoomType)) return;
            SpawnedObjects.Add(ObjectSpawner.SpawnWorkstation(this));
        }
    }
}
