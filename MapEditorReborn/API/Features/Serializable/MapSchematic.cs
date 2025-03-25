// -----------------------------------------------------------------------
// <copyright file="MapSchematic.cs" company="MapEditorReborn">
// Copyright (c) MapEditorReborn. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace MapEditorReborn.API.Features.Serializable
{
    using global::MapEditorReborn.Interfaces;
    using PlayerRoles;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Vanilla;

    /// <summary>
    /// A tool used to save and load maps.
    /// </summary>
    [Serializable]
    public sealed class MapSchematic
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapSchematic"/> class.
        /// </summary>
        public MapSchematic()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MapSchematic"/> class.
        /// </summary>
        /// <param name="name">The name of the map.</param>
        public MapSchematic(string name) => Name = name;

        /// <summary>
        /// Gets the <see cref="MapSchematic"/> name.
        /// </summary>
        public string Name = "None";

        /// <summary>
        /// Gets a value indicating whether the default spawnpoints should be disabled.
        /// </summary>
        [Description("Whether the default player spawnpoints should be removed. Keep in mind, that given role spawnpoint will be removed only if there is at least one custom spawn point of that type.")]
        public bool RemoveDefaultSpawnPoints { get; internal set; }

        /// <summary>
        /// Gets possible role names for a ragdolls.
        /// </summary>
        [Description("List of possible names for ragdolls spawned by RagdollSpawnPoints.")]
        public Dictionary<RoleTypeId, List<string>> RagdollRoleNames { get; internal set; } = new()
        {
            { RoleTypeId.ClassD, new List<string> { "D-9341" } },
        };

        /// <summary>
        /// Gets the dictionary of vanilla doors settings.
        /// </summary>
        public Dictionary<string, VanillaDoorSerializable> VanillaDoors { get; private set; } = new();

        /// <summary>
        /// Gets the vanilla tesla properties.
        /// </summary>
        public VanillaTeslaProperties VanillaTeslaProperties { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="DoorSerializable"/>.
        /// </summary>
        public List<DoorSerializable> Doors { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="WorkstationSerializable"/>.
        /// </summary>
        public List<WorkstationSerializable> WorkStations { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="ItemSpawnPointSerializable"/>.
        /// </summary>
        public List<ItemSpawnPointSerializable> ItemSpawnPoints { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="PlayerSpawnPointSerializable"/>.
        /// </summary>
        public List<PlayerSpawnPointSerializable> PlayerSpawnPoints { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="RagdollSpawnPointSerializable"/>.
        /// </summary>
        public List<RagdollSpawnPointSerializable> RagdollSpawnPoints { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="ShootingTargetSerializable"/>.
        /// </summary>
        public List<ShootingTargetSerializable> ShootingTargets { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="PrimitiveSerializable"/>.
        /// </summary>
        public List<PrimitiveSerializable> Primitives { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="LightSourceSerializable"/>.
        /// </summary>
        public List<LightSourceSerializable> LightSources { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="RoomLightSerializable"/>.
        /// </summary>
        public List<RoomLightSerializable> RoomLights { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="SerializableTeleport"/>".
        /// </summary>
        public List<SerializableTeleport> Teleports { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="LockerSerializable"/>.
        /// </summary>
        public List<LockerSerializable> Lockers { get; private set; } = new();

        /// <summary>
        /// Gets the list of <see cref="SchematicSerializable"/>.
        /// </summary>
        public List<SchematicSerializable> Schematics { get; private set; } = new();

        /// <summary>
        /// Gets a list of all serializable objects <see cref="ISpawnManager"/>.
        /// </summary>
        public List<ISpawnManager> GetSerializedObjects()
        {
            var serializedObjects = new List<ISpawnManager>(Doors.Count + WorkStations.Count + ItemSpawnPoints.Count + PlayerSpawnPoints.Count + RagdollSpawnPoints.Count + ShootingTargets.Count + Primitives.Count + LightSources.Count + RoomLights.Count + Teleports.Count + Lockers.Count + Schematics.Count);
            serializedObjects.AddRange(Doors);
            serializedObjects.AddRange(ItemSpawnPoints);
            serializedObjects.AddRange(LightSources);
            serializedObjects.AddRange(Lockers);
            serializedObjects.AddRange(PlayerSpawnPoints);
            serializedObjects.AddRange(Primitives);
            serializedObjects.AddRange(RagdollSpawnPoints);
            serializedObjects.AddRange(RoomLights);
            serializedObjects.AddRange(Schematics);
            //If one teleport leads to another teleport, which is in a non-existent room, then in fact, MER does not transfer the player anywhere.
            serializedObjects.AddRange(Teleports);
            serializedObjects.AddRange(ShootingTargets);
            serializedObjects.AddRange(WorkStations);
            return serializedObjects;
        }

        /// <summary>
        /// Removes every currently saved object from all objects' lists.
        /// </summary>
        public void CleanupAll()
        {
            Doors.Clear();
            WorkStations.Clear();
            ItemSpawnPoints.Clear();
            PlayerSpawnPoints.Clear();
            RagdollSpawnPoints.Clear();
            ShootingTargets.Clear();
            Primitives.Clear();
            LightSources.Clear();
            RoomLights.Clear();
            Teleports.Clear();
            Lockers.Clear();
            Schematics.Clear();
        }
    }
}
