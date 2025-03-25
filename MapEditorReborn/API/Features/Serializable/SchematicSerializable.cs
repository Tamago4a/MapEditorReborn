// -----------------------------------------------------------------------
// <copyright file="SchematicSerializable.cs" company="MapEditorReborn">
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
    using static API;

    /// <summary>
    /// A tool used to spawn and save schematics.
    /// </summary>
    [Serializable]
    public class SchematicSerializable : SerializableObject, ISpawnManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SchematicSerializable"/> class.
        /// </summary>
        public SchematicSerializable()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SchematicSerializable"/> class.
        /// </summary>
        /// <param name="schematicName">The schematic's name.</param>
        public SchematicSerializable(string schematicName) => SchematicName = schematicName;

        /// <summary>
        /// Gets or sets the <see cref="SchematicSerializable"/>'s name.
        /// </summary>
        public string SchematicName { get; set; } = "None";

        public CullingType CullingType { get; set; } = CullingType.None;

        /// <summary>
        /// Gets or sets a value indicating whether the schematic can be picked up via the Gravity Gun.
        /// </summary>
        public bool IsPickable { get; set; }

        public void TryAddSpawnObject()
        {
            var schematic = ObjectSpawner.SpawnSchematic(this, null, null, null, null);
            if (schematic == null)
            {
                Log.Warn($"The schematic with \"{this.SchematicName}\" name does not exist or has an invalid name. Skipping...");
                return;
            }
            Log.Debug($"Trying to spawn a schematic named \"{this.SchematicName}\" at {this.RoomType}. X: ({this.Position.x}, Y: {this.Position.y}, Z: {this.Position.z})");
            if (!MapUtils.IsRoomExist(this.RoomType)) return;
            SpawnedObjects.Add(schematic);
        }
    }
}
