﻿using GameNetcodeStuff;
using LethalLib.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

namespace MysteryDice.Effects
{
    internal class InvertDoorLock : IEffect
    {
        public string Name => "InvertDoorLock";
        public EffectType Outcome => EffectType.Bad;
        public bool ShowDefaultTooltip => true;
        public string Tooltip => "Check the doors";

        public void Use()
        {
            Networker.Instance.DoorlockServerRPC();
        }

        public static void InvertDoors()
        {
            foreach (var door in GameObject.FindObjectsOfType<DoorLock>())
            {
                door.OpenOrCloseDoor(GameNetworkManager.Instance.localPlayerController);
                door.LockDoor();
            }
        }
    }
}
