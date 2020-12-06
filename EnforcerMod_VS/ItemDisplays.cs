﻿using System;
using UnityEngine;
using R2API;
using RoR2;
using R2API.Utils;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EnforcerPlugin
{
    public static class ItemDisplays
    {
        public static List<ItemDisplayRuleSet.NamedRuleGroup> list;
        public static List<ItemDisplayRuleSet.NamedRuleGroup> list2;

        public static GameObject capacitorPrefab;
        public static GameObject gatDronePrefab;

        private static Dictionary<string, GameObject> itemDisplayPrefabs = new Dictionary<string, GameObject>();

        public static void RegisterDisplays()
        {
            GameObject bodyPrefab = EnforcerPlugin.characterPrefab;

            GameObject model = bodyPrefab.GetComponentInChildren<ModelLocator>().modelTransform.gameObject;
            CharacterModel characterModel = model.GetComponent<CharacterModel>();

            PopulateDisplays();

            ItemDisplayRuleSet itemDisplayRuleSet = ScriptableObject.CreateInstance<ItemDisplayRuleSet>();

            list = new List<ItemDisplayRuleSet.NamedRuleGroup>();
            list2 = new List<ItemDisplayRuleSet.NamedRuleGroup>();

            //add item displays here
            #region DisplayRules
            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Jetpack",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBugWings"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.0214f, -0.0208f),
                            localAngles = new Vector3(45, 0, 0),
                            localScale = new Vector3(0.015f, 0.015f, 0.015f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "GoldGat",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = gatDronePrefab,
                            childName = "Pelvis",
                            localPos = new Vector3(0.08f, 0.15f, 0.05f),
                            localAngles = new Vector3(0, 90, 0),
                            localScale = new Vector3(0.015f, 0.015f, 0.015f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BFG",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBFG"),
                            childName = "Spine3",
                            localPos = new Vector3(0.0118f, 0.0301f, -0.0082f),
                            localAngles = new Vector3(0, 0, -30f),
                            localScale = new Vector3(0.03f, 0.03f, 0.03f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "CritGlasses",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGlasses"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.017f, 0.01f),
                            localAngles = new Vector3(-25, 0, 0),
                            localScale = new Vector3(0.027f, 0.028f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Syringe",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySyringeCluster"),
                            childName = "Spine3",
                            localPos = new Vector3(0.01002f, 0.02729f, 0.01233f),
                            localAngles = new Vector3(0, 112, 52),
                            localScale = new Vector3(0.012f, 0.012f, 0.012f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Behemoth",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBehemoth"),
                            childName = "Shotgun",
                            localPos = new Vector3(0.025f, 0, 0.025f),
                            localAngles = new Vector3(0, 0, -90),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBehemoth"),
                            childName = "Rifle",
                            localPos = new Vector3(3, 0, 2),
                            localAngles = new Vector3(0, 8, 270),
                            localScale = new Vector3(1, 1, 1),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBehemoth"),
                            childName = "SuperShotgun",
                            localPos = new Vector3(0.05f, -0.01f, 0.015f),
                            localAngles = new Vector3(0, 10, -100),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBehemoth"),
                            childName = "Needler",
                            localPos = new Vector3(-0.03f, 0, 0.03f),
                            localAngles = new Vector3(0, -15, 90),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Missile",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMissileLauncher"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.0225f, 0.0601f, -0.0129f),
                            localAngles = new Vector3(0, 0, 14.68f),
                            localScale = new Vector3(0.008f, 0.008f, 0.008f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Dagger",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDagger"),
                            childName = "Spine2",
                            localPos = new Vector3(0.005f, 0.0141f, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.08f, 0.08f, 0.08f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Hoof",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayHoof"),
                            childName = "KneeL",
                            localPos = new Vector3(-0.0025f, 0.012f, -0.0125f),
                            localAngles = new Vector3(60, 0, 0),
                            localScale = new Vector3(0.0125f, 0.0125f, 0.008f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "ChainLightning",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayUkulele"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.0057f, -0.0011f, -0.023f),
                            localAngles = new Vector3(0, 180, 90),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "GhostOnKill",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMask"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.0098f, 0.01f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Mushroom",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMushroom"),
                            childName = "ClavicleR",
                            localPos = new Vector3(0, 0.01f, 0),
                            localAngles = new Vector3(64, 0, 0),
                            localScale = new Vector3(0.0075f, 0.0075f, 0.0075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "AttackSpeedOnCrit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWolfPelt"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.016f, -0.005f),
                            localAngles = new Vector3(-25, 0, 0),
                            localScale = new Vector3(0.035f, 0.035f, 0.035f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BleedOnHit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTriTip"),
                            childName = "Spine3",
                            localPos = new Vector3(0.01261f, 0.04054f, 0.02003f),
                            localAngles = new Vector3(124, 0, 0),
                            localScale = new Vector3(0.025f, 0.025f, 0.025f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "WardOnLevel",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarbanner"),
                            childName = "Spine3",
                            localPos = new Vector3(0, -0.01383f, -0.02629f),
                            localAngles = new Vector3(0, 0, 90),
                            localScale = new Vector3(0.035f, 0.035f, 0.035f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "HealOnCrit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayScythe"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.0064f, 0.0177f, -0.023f),
                            localAngles = new Vector3(-145, 92, -94),
                            localScale = new Vector3(0.025f, 0.025f, 0.025f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "HealWhileSafe",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySnail"),
                            childName = "ClavicleL",
                            localPos = new Vector3(0, 0.01f, 0),
                            localAngles = new Vector3(0, 45, 90),
                            localScale = new Vector3(0.008f, 0.008f, 0.008f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Clover",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayClover"),
                            childName = "ClavicleL",
                            localPos = new Vector3(0, 0.01f, 0.01f),
                            localAngles = new Vector3(45, 0, 0),
                            localScale = new Vector3(0.06f, 0.06f, 0.06f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BarrierOnOverHeal",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAegis"),
                            childName = "ElbowL",
                            localPos = new Vector3(-0.0068f, 0.0204f, 0),
                            localAngles = new Vector3(-101, -90, 0),
                            localScale = new Vector3(0.03f, 0.03f, 0.03f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "GoldOnHit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBoneCrown"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.01f, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.1f, 0.1f, 0.1f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "WarCryOnMultiKill",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayPauldron"),
                            childName = "ShoulderL",
                            localPos = new Vector3(-0.015f, 0.01f, 0),
                            localAngles = new Vector3(60, 270, 0),
                            localScale = new Vector3(0.075f, 0.075f, 0.075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "SprintArmor",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBuckler"),
                            childName = "ShoulderR",
                            localPos = new Vector3(0, 0.028f, -0.008f),
                            localAngles = new Vector3(0, 180, 90),
                            localScale = new Vector3(0.015f, 0.015f, 0.015f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "IceRing",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayIceRing"),
                            childName = "ElbowL",
                            localPos = new Vector3(0.0004f, 0.0267f, 0),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.07575839f, 0.101f, 0.101f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "FireRing",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFireRing"),
                            childName = "ElbowL",
                            localPos = new Vector3(0.00042f, 0.0313f, 0),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.072f, 0.101f, 0.101f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "UtilitySkillMagazine",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                            childName = "ClavicleL",
                            localPos = new Vector3(0, 0.015f, 0),
                            localAngles = new Vector3(0, 22, -90),
                            localScale = new Vector3(0.075f, 0.075f, 0.075f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAfterburnerShoulderRing"),
                            childName = "ClavicleR",
                            localPos = new Vector3(0, 0.015f, 0),
                            localAngles = new Vector3(0, -22, 90),
                            localScale = new Vector3(0.075f, 0.075f, 0.075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "JumpBoost",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWaxBird"),
                            childName = "Head",
                            localPos = new Vector3(0, -0.028f, -0.0037f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.08f, 0.08f, 0.08f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            if (EnforcerPlugin.sillyHammer.Value)
            {
                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ArmorReductionOnHit",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "Spine1",
                            localPos = new Vector3(0, 0.02f, 0),
                            localAngles = new Vector3(70, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.05f, 0),
                            localAngles = new Vector3(270, 0, 0),
                            localScale = new Vector3(0.025f, 0.025f, 0.025f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "LegL",
                            localPos = new Vector3(0, 0, 0),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "KneeL",
                            localPos = new Vector3(0, 0.035f, -0.005f),
                            localAngles = new Vector3(270, 0, 0),
                            localScale = new Vector3(0.01f, 0.025f, 0.01f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "LegR",
                            localPos = new Vector3(0, 0, 0),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "KneeR",
                            localPos = new Vector3(0, 0.035f, -0.005f),
                            localAngles = new Vector3(270, 0, 0),
                            localScale = new Vector3(0.01f, 0.025f, 0.01f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "ShoulderL",
                            localPos = new Vector3(0, 0, 0),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.014f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "ShoulderR",
                            localPos = new Vector3(0, 0, 0),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.014f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "ElbowL",
                            localPos = new Vector3(0, 0.06f, 0),
                            localAngles = new Vector3(270, 0, 0),
                            localScale = new Vector3(0.025f, 0.025f, 0.02f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                            childName = "ElbowR",
                            localPos = new Vector3(0, 0.06f, 0),
                            localAngles = new Vector3(270, 0, 0),
                            localScale = new Vector3(0.025f, 0.025f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                        }
                    }
                });

            }
            else
            {
                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ArmorReductionOnHit",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadDisplay("DisplayWarhammer"),
                                childName = "Spine3",
                                localPos = new Vector3(0, 0.03f, -0.023f),
                                localAngles = new Vector3(-90, 0, 0),
                                localScale = new Vector3(0.025f, 0.025f, 0.025f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });
            }

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "NearbyDamageBonus",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDiamond"),
                            childName = "ElbowR",
                            localPos = new Vector3(-0.0031f, 0.0297f, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.015f, 0.015f, 0.015f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "ArmorPlate",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRepulsionArmorPlate"),
                            childName = "Shield",
                            localPos = new Vector3(2.5f, 0.5f, -2),
                            localAngles = new Vector3(0, 0, 180),
                            localScale = new Vector3(8, 4, 8),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "CommandMissile",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMissileRack"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.0173f, -0.0261f),
                            localAngles = new Vector3(90, 180, 0),
                            localScale = new Vector3(0.058f, 0.058f, 0.058f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Feather",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFeather"),
                            childName = "ElbowL",
                            localPos = new Vector3(-0.0047f, 0.0185f, -0.0034f),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.004f, 0.004f, 0.004f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Crowbar",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayCrowbar"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.0022f, 0.0168f, -0.023f),
                            localAngles = new Vector3(45, 90, 0),
                            localScale = new Vector3(0.04f, 0.04f, 0.04f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "FallBoots",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGravBoots"),
                            childName = "KneeR",
                            localPos = new Vector3(0, 0.02246f, -0.00456f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.024f, 0.024f, 0.024f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGravBoots"),
                            childName = "KneeL",
                            localPos = new Vector3(0, 0.02246f, -0.00456f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.024f, 0.024f, 0.024f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "ExecuteLowHealthElite",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGuillotine"),
                            childName = "LegR",
                            localPos = new Vector3(-0.0152f, 0.0308f, 0),
                            localAngles = new Vector3(90, -90, 0),
                            localScale = new Vector3(0.022f, 0.022f, 0.022f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "EquipmentMagazine",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBattery"),
                            childName = "Spine3",
                            localPos = new Vector3(0.0118f, 0.0129f, -0.0246f),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "NovaOnHeal",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                            childName = "Head",
                            localPos = new Vector3(0.0094f, 0.01f, 0),
                            localAngles = new Vector3(0, 0, 20),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDevilHorns"),
                            childName = "Head",
                            localPos = new Vector3(-0.0094f, 0.01f, 0),
                            localAngles = new Vector3(0, 0, -20),
                            localScale = new Vector3(-0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Infusion",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayInfusion"),
                            childName = "Pelvis",
                            localPos = new Vector3(-0.01452f, 0.02237f, 0.01542f),
                            localAngles = new Vector3(0, -20, 0),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Medkit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMedkit"),
                            childName = "LegR",
                            localPos = new Vector3(-0.0148f, 0.0061f, 0),
                            localAngles = new Vector3(80, 90, 0),
                            localScale = new Vector3(0.075f, 0.075f, 0.075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Bandolier",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBandolier"),
                            childName = "Spine1",
                            localPos = new Vector3(0, 0.0452f, 0.005f),
                            localAngles = new Vector3(-134.304f, -90, 100.864f),
                            localScale = new Vector3(0.084f, 0.03f, 0.08f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BounceNearby",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayHook"),
                            childName = "Shield",
                            localPos = new Vector3(0, 0, 7.5f),
                            localAngles = new Vector3(0, 0, 25),
                            localScale = new Vector3(1, 1, 1),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "IgniteOnKill",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGasoline"),
                            childName = "LegL",
                            localPos = new Vector3(0.0142f, 0.0123f, 0),
                            localAngles = new Vector3(96, 90, 90),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "StunChanceOnHit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayStunGrenade"),
                            childName = "LegR",
                            localPos = new Vector3(0, 0.04f, -0.02f),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.1f, 0.1f, 0.1f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Firework",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFirework"),
                            childName = "Spine1",
                            localPos = new Vector3(-0.02187928f, 0.02602776f, 0.01359699f),
                            localAngles = new Vector3(-108, 102, -99),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "LunarDagger",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayLunarDagger"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0, -0.0219f),
                            localAngles = new Vector3(-54, 90, -90),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Knurl",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayKnurl"),
                            childName = "Spine3",
                            localPos = new Vector3(0.01961f, 0.0076f, 0.02533f),
                            localAngles = new Vector3(0, 116, 0),
                            localScale = new Vector3(0.0075f, 0.0075f, 0.0075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BeetleGland",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBeetleGland"),
                            childName = "ClavicleL",
                            localPos = new Vector3(-0.02f, 0.02f, 0),
                            localAngles = new Vector3(0, 206, 64),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "SprintBonus",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySoda"),
                            childName = "Spine1",
                            localPos = new Vector3(-0.015f, 0.01f, 0.015f),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.03f, 0.03f, 0.03f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "SecondarySkillMagazine",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                            childName = "Shotgun",
                            localPos = new Vector3(-0.0244f, 0, -0.01927f),
                            localAngles = new Vector3(0, 2, 90),
                            localScale = new Vector3(0.0065f, 0.0065f, 0.0065f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                            childName = "Rifle",
                            localPos = new Vector3(1, 0, -2),
                            localAngles = new Vector3(0, 90, 90),
                            localScale = new Vector3(1, 1, 1),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                            childName = "SuperShotgun",
                            localPos = new Vector3(0.005f, -0.003f, -0.02f),
                            localAngles = new Vector3(0, -45, 90),
                            localScale = new Vector3(0.005f, 0.005f, 0.005f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDoubleMag"),
                            childName = "Needler",
                            localPos = new Vector3(0, 0, -0.03f),
                            localAngles = new Vector3(0, 315, 90),
                            localScale = new Vector3(0.0075f, 0.0075f, 0.0075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "StickyBomb",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayStickyBomb"),
                            childName = "Spine1",
                            localPos = new Vector3(-0.018f, 0.02f, -0.01f),
                            localAngles = new Vector3(0, 45, 45),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "TreasureCache",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayKey"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.00693f, -0.0298f, -0.02f),
                            localAngles = new Vector3(90, 0, -14),
                            localScale = new Vector3(0.09f, 0.09f, 0.09f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BossDamageBonus",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAPRound"),
                            childName = "Spine1",
                            localPos = new Vector3(0.01988f, 0.02043f, -0.00202f),
                            localAngles = new Vector3(-90, 0, -84),
                            localScale = new Vector3(0.04f, 0.04f, 0.04f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "SlowOnHit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBauble"),
                            childName = "Spine3",
                            localPos = new Vector3(0.0272f, -0.0164f, -0.028f),
                            localAngles = new Vector3(0, 0, 64),
                            localScale = new Vector3(0.0344364f, 0.0344364f, 0.0344364f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "ExtraLife",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayHippo"),
                            childName = "Shield",
                            localPos = new Vector3(0, 1.15f, -3.65f),
                            localAngles = new Vector3(-80, 180, 0),
                            localScale = new Vector3(5, 5, 5),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "KillEliteFrenzy",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBrainstalk"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.015f, 0.0033f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.02187931f, 0.02187931f, 0.02187931f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "RepeatHeal",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayCorpseFlower"),
                            childName = "ClavicleR",
                            localPos = new Vector3(0.00647f, 0.01332f, 0),
                            localAngles = new Vector3(0, -38, -90),
                            localScale = new Vector3(0.02119026f, 0.02119026f, 0.02119026f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "AutoCastEquipment",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFossil"),
                            childName = "Spine3",
                            localPos = new Vector3(0.0063f, -0.0223f, -0.022f),
                            localAngles = new Vector3(0, 90, 0),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "IncreaseHealing",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAntler"),
                            childName = "Head",
                            localPos = new Vector3(0.0083f, 0.015f, -0.0054f),
                            localAngles = new Vector3(0, 90, 0),
                            localScale = new Vector3(0.035f, 0.035f, 0.035f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAntler"),
                            childName = "Head",
                            localPos = new Vector3(-0.0083f, 0.015f, -0.0054f),
                            localAngles = new Vector3(0, -90, 0),
                            localScale = new Vector3(0.035f, 0.035f, 0.035f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "TitanGoldDuringTP",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGoldHeart"),
                            childName = "Spine3",
                            localPos = new Vector3(0.00011f, 0.00371f, 0.02213f),
                            localAngles = new Vector3(0, 0, -75),
                            localScale = new Vector3(0.03f, 0.03f, 0.03f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "SprintWisp",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBrokenMask"),
                            childName = "ClavicleL",
                            localPos = new Vector3(0, 0.02f, 0.01f),
                            localAngles = new Vector3(328, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BarrierOnKill",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBrooch"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.01043f, 0.01134f, 0.025f),
                            localAngles = new Vector3(45, 90, 90),
                            localScale = new Vector3(0.04f, 0.04f, 0.04f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "TPHealingNova",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGlowFlower"),
                            childName = "ClavicleL",
                            localPos = new Vector3(0, -0.03373f, 0.00664f),
                            localAngles = new Vector3(64, 0, 0),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "LunarUtilityReplacement",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBirdFoot"),
                            childName = "LegR",
                            localPos = new Vector3(0, 0.0268f, -0.0169f),
                            localAngles = new Vector3(0, -90, 0),
                            localScale = new Vector3(0.044f, 0.044f, 0.044f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Thorns",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRazorwireLeft"),
                            childName = "ElbowR",
                            localPos = new Vector3(-0.006f, 0, 0),
                            localAngles = new Vector3(270, 0, 0),
                            localScale = new Vector3(0.04f, 0.06f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "LunarPrimaryReplacement",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBirdEye"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.0075f, 0.01f),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.025f, 0.025f, 0.025f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "NovaOnLowHealth",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayJellyGuts"),
                            childName = "LegR",
                            localPos = new Vector3(0, 0.0135f, -0.0077f),
                            localAngles = new Vector3(-41, 0, 0),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "LunarTrinket",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBeads"),
                            childName = "ElbowL",
                            localPos = new Vector3(-0.0031f, 0.0147f, 0.0033f),
                            localAngles = new Vector3(0, 0, 90),
                            localScale = new Vector3(0.152965f, 0.152965f, 0.152965f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Plant",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayInterstellarDeskPlant"),
                            childName = "ClavicleR",
                            localPos = new Vector3(0, 0.01f, 0),
                            localAngles = new Vector3(342, 0, 0),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Bear",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBear"),
                            childName = "Shield",
                            localPos = new Vector3(0, 1.28f, 0.97f),
                            localAngles = new Vector3(-77, 180, 0),
                            localScale = new Vector3(5, 5, 5),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "DeathMark",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDeathMark"),
                            childName = "HandL",
                            localPos = new Vector3(0.0053f, 0.0128f, 0.0011f),
                            localAngles = new Vector3(0, 0, 180),
                            localScale = new Vector3(0.002616626f, 0.002616626f, 0.002616626f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "ExplodeOnDeath",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWilloWisp"),
                            childName = "Spine1",
                            localPos = new Vector3(0.02f, 0.02f, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.005f, 0.005f, 0.005f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Seed",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySeed"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.035f, -0.01f),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.006f, 0.006f, 0.006f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "SprintOutOfCombat",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWhip"),
                            childName = "Spine1",
                            localPos = new Vector3(0.02f, 0, -0.015f),
                            localAngles = new Vector3(0, 45, 15),
                            localScale = new Vector3(0.05f, 0.05f, 0.03f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "CooldownOnCrit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySkull"),
                            childName = "HandR",
                            localPos = new Vector3(0, 0.01f, 0),
                            localAngles = new Vector3(0, 90, 180),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Phasing",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayStealthkit"),
                            childName = "KneeL",
                            localPos = new Vector3(-0.0025f, 0, -0.01f),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "PersonalShield",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShieldGenerator"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.0075f, 0.01f, 0.025f),
                            localAngles = new Vector3(45, 90, -90),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "ShockNearby",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTeslaCoil"),
                            childName = "ElbowL",
                            localPos = new Vector3(0, 0.01f, 0),
                            localAngles = new Vector3(0, 0, 90),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "ShieldOnly",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShieldBug"),
                            childName = "Head",
                            localPos = new Vector3(0.0083f, 0.0207f, -0.0054f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.035f, 0.035f, 0.035f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShieldBug"),
                            childName = "Head",
                            localPos = new Vector3(-0.0083f, 0.0207f, -0.0054f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(-0.035f, 0.035f, 0.035f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "AlienHead",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAlienHead"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.02f, 0.02f, -0.015f),
                            localAngles = new Vector3(180, 45, 180),
                            localScale = new Vector3(0.1f, 0.1f, 0.1f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "HeadHunter",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySkullCrown"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.02f, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.05f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "EnergizedOnEquipmentUse",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWarHorn"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.04f, -0.01f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.04f, 0.04f, 0.04f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "RegenOnKill",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySteakCurved"),
                            childName = "Shield",
                            localPos = new Vector3(2, 0, 7.8f),
                            localAngles = new Vector3(-25, 0, 180),
                            localScale = new Vector3(5, 5, 5),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                //this one is supposed to be 6 display rules because hopoo is fuCKING RETARDED but i'm only doing one because it's a shit item anyway
                name = "Tooth",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayToothMeshLarge"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.03f, 0.015f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.5f, 0.5f, 0.5f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Pearl",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayPearl"),
                            childName = "HandR",
                            localPos = new Vector3(0, 0, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "ShinyPearl",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayShinyPearl"),
                            childName = "HandL",
                            localPos = new Vector3(0, 0, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BonusGoldPackOnKill",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTome"),
                            childName = "LegR",
                            localPos = new Vector3(0, 0.035f, -0.016f),
                            localAngles = new Vector3(10, 0, 0),
                            localScale = new Vector3(0.005f, 0.005f, 0.005f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Squid",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySquidTurret"),
                            childName = "Spine3",
                            localPos = new Vector3(0.015f, 0, -0.025f),
                            localAngles = new Vector3(0, -90, 90),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Icicle",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFrostRelic"),
                            childName = "Spine3",
                            localPos = new Vector3(0.05f, 0, -0.1f),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(1, 1, 1),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Talisman",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTalisman"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.05f, 0, -0.1f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(1, 1, 1),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "LaserTurbine",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayLaserTurbine"),
                            childName = "Spine3",
                            localPos = new Vector3(0.015f, -0.01f, -0.023f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "FocusConvergence",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFocusedConvergence"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0, -0.15f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.1f, 0.1f, 0.1f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Incubator",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayAncestralIncubator"),
                            childName = "Spine3",
                            localPos = new Vector3(-0.01f, 0.01f, 0),
                            localAngles = new Vector3(-25, 25, 0),
                            localScale = new Vector3(0.005f, 0.005f, 0.005f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "FireballsOnHit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFireballsOnHit"),
                            childName = "ElbowL",
                            localPos = new Vector3(0, 0.02f, -0.015f),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.0075f, 0.0075f, 0.0075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "SiphonOnLowHealth",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySiphonOnLowHealth"),
                            childName = "Spine1",
                            localPos = new Vector3(0.01f, 0.0075f, 0.02f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.0075f, 0.0075f, 0.0075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BleedOnHitAndExplode",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBleedOnHitAndExplode"),
                            childName = "LegR",
                            localPos = new Vector3(-0.002f, 0.01f, 0.02f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.005f, 0.005f, 0.005f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "MonstersOnShrineUse",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMonstersOnShrineUse"),
                            childName = "LegR",
                            localPos = new Vector3(0, 0.01f, -0.0125f),
                            localAngles = new Vector3(0, -90, 0),
                            localScale = new Vector3(0.0075f, 0.0075f, 0.0075f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "RandomDamageZone",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRandomDamageZone"),
                            childName = "HandL",
                            localPos = new Vector3(-0.01f, 0.005f, 0.005f),
                            localAngles = new Vector3(0, 90, 90),
                            localScale = new Vector3(0.01f, 0.005f, 0.007f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Fruit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayFruit"),
                            childName = "Spine3",
                            localPos = new Vector3(0.0193f, -0.0069f, 0.0025f),
                            localAngles = new Vector3(0, -70, 30),
                            localScale = new Vector3(0.02759527f, 0.02759527f, 0.02759527f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "AffixRed",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                            childName = "Head",
                            localPos = new Vector3(0.0072f, 0.015f, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.009661668f, 0.009661668f, 0.009661668f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteHorn"),
                            childName = "Head",
                            localPos = new Vector3(-0.0072f, 0.015f, 0),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(-0.009661668f, 0.009661668f, 0.009661668f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "AffixBlue",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.015f, 0.0168f),
                            localAngles = new Vector3(-45, 0, 0),
                            localScale = new Vector3(0.032f, 0.032f, 0.032f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteRhinoHorn"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.02f, 0.01012f),
                            localAngles = new Vector3(-69, 0, 0),
                            localScale = new Vector3(0.016f, 0.016f, 0.016f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "AffixWhite",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteIceCrown"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.0254f, -0.0012f),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.002664f, 0.002664f, 0.002664f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "AffixPoison",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteUrchinCrown"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.015f, 0),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.005f, 0.005f, 0.005f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "AffixHaunted",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEliteStealthCrown"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.025f, 0),
                            localAngles = new Vector3(-90, 0, 0),
                            localScale = new Vector3(0.005f, 0.005f, 0.005f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "CritOnUse",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayNeuralImplant"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.005f, 0.025f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.025f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "DroneBackup",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRadio"),
                            childName = "Spine1",
                            localPos = new Vector3(0.02f, 0.02f, 0),
                            localAngles = new Vector3(-20, 90, 0),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Lightning",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.capacitorPrefab,
                            childName = "ClavicleL",
                            localPos = new Vector3(-0.0128f, -0.0046f, 0.0311f),
                            localAngles = new Vector3(64, 12, 120),
                            localScale = new Vector3(0.06833912f, 0.06833912f, 0.06833912f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "BurnNearby",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayPotion"),
                            childName = "Spine3",
                            localPos = new Vector3(0.02f, 0.04f, 0),
                            localAngles = new Vector3(0, 0, -45),
                            localScale = new Vector3(0.005f, 0.005f, 0.005f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "CrippleWard",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEffigy"),
                            childName = "Spine3",
                            localPos = new Vector3(0.0134f, 0.02949f, -0.00808f),
                            localAngles = new Vector3(0, 180, 0),
                            localScale = new Vector3(0.04f, 0.04f, 0.04f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "QuestVolatileBattery",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayBatteryArray"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.0189f, -0.0274f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "GainArmor",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayElephantFigure"),
                            childName = "KneeR",
                            localPos = new Vector3(0, 0.02f, 0.008f),
                            localAngles = new Vector3(115, 0, 0),
                            localScale = new Vector3(0.05f, 0.05f, 0.05f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Recycle",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayRecycler"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.015f, -0.03f),
                            localAngles = new Vector3(0, 90, 0),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "FireBallDash",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayEgg"),
                            childName = "Spine3",
                            localPos = new Vector3(0.015f, 0.035f, -0.01f),
                            localAngles = new Vector3(0, 90, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Cleanse",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayWaterPack"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0, -0.02f),
                            localAngles = new Vector3(0, 180, 0),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Tonic",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTonic"),
                            childName = "Spine3",
                            localPos = new Vector3(0.015f, 0.045f, 0),
                            localAngles = new Vector3(0, 90, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Gateway",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayVase"),
                            childName = "Spine3",
                            localPos = new Vector3(0.01f, 0.04f, -0.015f),
                            localAngles = new Vector3(-45, 0, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Meteor",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayMeteor"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.05f, -0.15f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(1, 1, 1),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Saw",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplaySawmerang"),
                            childName = "ElbowL",
                            localPos = new Vector3(-0.05f, 0.05f, 0),
                            localAngles = new Vector3(0, 90, 0),
                            localScale = new Vector3(0.2f, 0.2f, 0.2f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Blackhole",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayGravCube"),
                            childName = "Spine3",
                            localPos = new Vector3(0, 0.05f, -0.15f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(1, 1, 1),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "Scanner",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayScanner"),
                            childName = "Spine1",
                            localPos = new Vector3(0.025f, 0.01f, 0),
                            localAngles = new Vector3(-90, 90, 0),
                            localScale = new Vector3(0.02f, 0.02f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "DeathProjectile",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayDeathProjectile"),
                            childName = "Spine1",
                            localPos = new Vector3(-0.01f, 0.005f, -0.025f),
                            localAngles = new Vector3(0, 180, 0),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "LifestealOnHit",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayLifestealOnHit"),
                            childName = "Head",
                            localPos = new Vector3(0, 0.03f, 0.01f),
                            localAngles = new Vector3(90, 0, 0),
                            localScale = new Vector3(0.0275f, 0.0275f, 0.02f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "TeamWarCry",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadDisplay("DisplayTeamWarCry"),
                            childName = "Spine1",
                            localPos = new Vector3(0, 0.015f, 0.03f),
                            localAngles = new Vector3(0, 0, 0),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                    }
                }
            });
            #endregion

            //aetherium displays
            #region Aetherium
            if (EnforcerPlugin.aetheriumInstalled)
            {
                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMAccursedPotion",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("AccursedPotion"),
                                childName = "Spine1",
                                localPos = new Vector3(0.1f, 0.15f, -0.04f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.015f, 0.015f, 0.015f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMAlienMagnet",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("AlienMagnet"),
                                childName = "Root",
                                localPos = new Vector3(0.1f, 0.15f, -0.04f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.015f, 0.015f, 0.015f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMVoidheart",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("VoidHeart"),
                                childName = "Spine3",
                                localPos = new Vector3(0, 0, 0),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.0125f, 0.0125f, 0.0125f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMSharkTeeth",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("SharkTeeth"),
                                childName = "LegL",
                                localPos = new Vector3(0, 0.06f, 0),
                                localAngles = new Vector3(0, 0, 300),
                                localScale = new Vector3(0.05f, 0.05f, 0.03f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMBloodSoakedShield",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("BloodSoakedShield"),
                                childName = "ElbowL",
                                localPos = new Vector3(-0.01f, 0.01f, 0),
                                localAngles = new Vector3(0, 270, 0),
                                localScale = new Vector3(0.03f, 0.03f, 0.03f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMInspiringDrone",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("InspiringDrone"),
                                childName = "Root",
                                localPos = new Vector3(-0.1f, 0.15f, -0.04f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.015f, 0.015f, 0.015f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMFeatheredPlume",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("FeatheredPlume"),
                                childName = "Head",
                                localPos = new Vector3(0, 0.02f, -0.01f),
                                localAngles = new Vector3(335, 0, 0),
                                localScale = new Vector3(0.05f, 0.05f, 0.05f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMShieldingCore",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("ShieldingCore"),
                                childName = "Spine3",
                                localPos = new Vector3(0, 0.02f, -0.025f),
                                localAngles = new Vector3(0, 90, 0),
                                localScale = new Vector3(0.01f, 0.01f, 0.01f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMUnstableDesign",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("UnstableDesign"),
                                childName = "Spine3",
                                localPos = new Vector3(0, -0.01f, -0.02f),
                                localAngles = new Vector3(0, 45, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMWeightedAnklet",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("WeightedAnklet"),
                                childName = "KneeL",
                                localPos = new Vector3(-0.002f, 0.01f, -0.003f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.02f, 0.025f, 0.025f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMBlasterSword",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadAetheriumDisplay("BlasterSword"),
                            childName = "Shotgun",
                            localPos = new Vector3(0.1f, 0, 0),
                            localAngles = new Vector3(0, 0, 90),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadAetheriumDisplay("BlasterSword"),
                            childName = "Rifle",
                            localPos = new Vector3(5, 0, 1),
                            localAngles = new Vector3(0, 0, 90),
                            localScale = new Vector3(1, 1, 1),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadAetheriumDisplay("BlasterSword"),
                            childName = "SuperShotgun",
                            localPos = new Vector3(0.06f, 0, 0.005f),
                            localAngles = new Vector3(0, 0, 85),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        },
                        new ItemDisplayRule
                        {
                            ruleType = ItemDisplayRuleType.ParentedPrefab,
                            followerPrefab = ItemDisplays.LoadAetheriumDisplay("BlasterSword"),
                            childName = "Needler",
                            localPos = new Vector3(-0.04f, 0, -0.005f),
                            localAngles = new Vector3(0, 25, 270),
                            localScale = new Vector3(0.01f, 0.01f, 0.01f),
                            limbMask = LimbFlags.None
                        }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMWitchesRing",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("WitchesRing"),
                                childName = "ElbowL",
                                localPos = new Vector3(0, 0, 0.02f),
                                localAngles = new Vector3(0, 270, 0),
                                localScale = new Vector3(0.04f, 0.04f, 0.04f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ATHRMAccursedPotion",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadAetheriumDisplay("AccursedPotion"),
                                childName = "Spine1",
                                localPos = new Vector3(0.02f, 0.025f, 0),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.05f, 0.05f, 0.05f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });
            }
            #endregion

            //sivsitems displays
            #region SivsItems
            if (EnforcerPlugin.sivsItemsInstalled)
            {
                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "BeetlePlush",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSivDisplay("BeetlePlush"),
                                childName = "Spine3",
                                localPos = new Vector3(0f, 0.03f, -0.025f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "BisonShield",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSivDisplay("BisonShield"),
                                childName = "ElbowL",
                                localPos = new Vector3(-0.005f, 0.03f, 0),
                                localAngles = new Vector3(0, 270, 0),
                                localScale = new Vector3(0.075f, 0.075f, 0.075f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "FlameGland",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSivDisplay("FlameGland"),
                                childName = "Spine3",
                                localPos = new Vector3(0.02f, -0.01f, 0),
                                localAngles = new Vector3(0, 270, 0),
                                localScale = new Vector3(0.05f, 0.05f, 0.05f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "Geode",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSivDisplay("Geode"),
                                childName = "LegL",
                                localPos = new Vector3(0, 0.035f, -0.01f),
                                localAngles = new Vector3(90, 0, 0),
                                localScale = new Vector3(0.02f, 0.03f, 0.03f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "ImpEye",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSivDisplay("ImpEye"),
                                childName = "Head",
                                localPos = new Vector3(0, 0.008f, 0.005f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "NullSeed",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSivDisplay("NullSeed"),
                                childName = "Root",
                                localPos = new Vector3(0.1f, 0.15f, 0),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(2, 2, 2),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "Tarbine",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSivDisplay("Tarbine"),
                                childName = "HandL",
                                localPos = new Vector3(0.005f, 0.02f, 0.02f),
                                localAngles = new Vector3(0, 180, 0),
                                localScale = new Vector3(0.065f, 0.065f, 0.065f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "Tentacle",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSivDisplay("Tentacle"),
                                childName = "Head",
                                localPos = new Vector3(0f, 0.015f, 0f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });
            }
            #endregion


            //supply drop displays
            #region SupplyDrop
            if (EnforcerPlugin.supplyDropInstalled)
            {
                /*list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPUnassumingTie",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("UnassumingTie"),
<<<<<<< Updated upstream
=======
                                childName = "Spine3",
                                localPos = new Vector3(0f, 0.03f, -0.025f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPBloodBook",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("BloodBook"),
                                childName = "Root",
                                localPos = new Vector3(0f, 0.03f, -0.025f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPElectroPlankton",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("ElectroPlankton"),
                                childName = "Spine3",
                                localPos = new Vector3(0f, 0.03f, -0.025f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPHardenedBoneFragments",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("HardenedBoneFragments"),
                                childName = "Spine3",
                                localPos = new Vector3(0f, 0.03f, -0.025f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPQSGen",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("QSGen"),
                                childName = "ElbowL",
                                localPos = new Vector3(0f, 0.03f, -0.025f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPSalvagedWires",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("SalvagedWires"),
                                childName = "LegL",
                                localPos = new Vector3(0f, 0.03f, -0.025f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPShellPlating",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("ShellPlating"),
>>>>>>> Stashed changes
                                childName = "Spine3",
                                localPos = new Vector3(0f, 0.03f, -0.025f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });*/

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPBloodBook",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("BloodBook"),
                                childName = "Root",
                                localPos = new Vector3(0f, 0.2f, -0.2f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.1f, 0.1f, 0.1f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPElectroPlankton",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("ElectroPlankton"),
                                childName = "Spine3",
                                localPos = new Vector3(0, -0.025f, -0.025f),
                                localAngles = new Vector3(0, 0, 90),
                                localScale = new Vector3(0.01f, 0.01f, 0.01f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPHardenedBoneFragments",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("HardenedBoneFragments"),
                                childName = "Spine3",
                                localPos = new Vector3(0f, 0.03f, 0.03f),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(0.2f, 0.2f, 0.2f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPQSGen",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("QSGen"),
                                childName = "ElbowL",
                                localPos = new Vector3(0, 0, 0),
                                localAngles = new Vector3(0, 0, 90),
                                localScale = new Vector3(0.01f, 0.01f, 0.01f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPSalvagedWires",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("SalvagedWires"),
                                childName = "LegL",
                                localPos = new Vector3(0, 0.05f, -0.02f),
                                localAngles = new Vector3(0, 90, 180),
                                localScale = new Vector3(0.04f, 0.04f, 0.04f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });

                list.Add(new ItemDisplayRuleSet.NamedRuleGroup
                {
                    name = "SUPPDRPShellPlating",
                    displayRuleGroup = new DisplayRuleGroup
                    {
                        rules = new ItemDisplayRule[]
                        {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = ItemDisplays.LoadSupplyDropDisplay("ShellPlating"),
                                childName = "Spine3",
                                localPos = new Vector3(0, 0, 0.0035f),
                                localAngles = new Vector3(30, 0, 0),
                                localScale = new Vector3(0.02f, 0.02f, 0.02f),
                                limbMask = LimbFlags.None
                            }
                        }
                    }
                });
            }
            #endregion
            //apply displays here

            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            ItemDisplayRuleSet.NamedRuleGroup[] value = list.ToArray();
            ItemDisplayRuleSet.NamedRuleGroup[] value2 = list2.ToArray();
            typeof(ItemDisplayRuleSet).GetField("namedItemRuleGroups", bindingAttr).SetValue(itemDisplayRuleSet, value);
            typeof(ItemDisplayRuleSet).GetField("namedEquipmentRuleGroups", bindingAttr).SetValue(itemDisplayRuleSet, value2);

            characterModel.itemDisplayRuleSet = itemDisplayRuleSet;
        }

/*        public static void RegisterHarbCrateDisplays()
        {
            Debug.Log("setting up harbcrate stuff");
            if (HarbCrate.HarbCratePlugin.AllPickups["BrawnOverBrain"] != null) Debug.Log("1");
            if (HarbCrate.HarbCratePlugin.AllPickups["BoB"] != null) Debug.Log("2");
            if (HarbCrate.HarbCratePlugin.AllPickups["HC_BOB"] != null) Debug.Log("3");
            if (HarbCrate.HarbCratePlugin.AllPickups["Brawn over Brain"] != null) Debug.Log("4");

            GameObject bodyPrefab = EnforcerPlugin.characterPrefab;

            GameObject model = bodyPrefab.GetComponentInChildren<ModelLocator>().modelTransform.gameObject;
            CharacterModel characterModel = model.GetComponent<CharacterModel>();

            ItemDisplayRuleSet itemDisplayRuleSet = characterModel.itemDisplayRuleSet;

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "HC_BOB",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = Resources.Load<GameObject>(HarbCrate.HarbCratePlugin.AllPickups["BrawnOverBrain"].AssetPath),
                                childName = "Spine3",
                                localPos = new Vector3(0, 0, 0),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(1, 1, 1),
                                limbMask = LimbFlags.None
                            }
                    }
                }
            });

            list.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "HC_MAXSHIELDONMULTIKILL",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = Resources.Load<GameObject>(HarbCrate.HarbCratePlugin.AllPickups["ObsidianBouche"].AssetPath),
                                childName = "HandL",
                                localPos = new Vector3(0, 0, 0),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(1, 1, 1),
                                limbMask = LimbFlags.None
                            }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "HC_COLDSNAP",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = Resources.Load<GameObject>(HarbCrate.HarbCratePlugin.AllPickups["Coldsnap"].AssetPath),
                                childName = "LegL",
                                localPos = new Vector3(0, 0, 0),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(1, 1, 1),
                                limbMask = LimbFlags.None
                            }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "HC_LUCKJUICE",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = Resources.Load<GameObject>(HarbCrate.HarbCratePlugin.AllPickups["DivinationDistillate"].AssetPath),
                                childName = "Spine1",
                                localPos = new Vector3(0, 0, 0),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(1, 1, 1),
                                limbMask = LimbFlags.None
                            }
                    }
                }
            });

            list2.Add(new ItemDisplayRuleSet.NamedRuleGroup
            {
                name = "HC_WORMJAR",
                displayRuleGroup = new DisplayRuleGroup
                {
                    rules = new ItemDisplayRule[]
                    {
                            new ItemDisplayRule
                            {
                                ruleType = ItemDisplayRuleType.ParentedPrefab,
                                followerPrefab = Resources.Load<GameObject>(HarbCrate.HarbCratePlugin.AllPickups["TheWrithingJar"].AssetPath),
                                childName = "Spine1",
                                localPos = new Vector3(0, 0, 0),
                                localAngles = new Vector3(0, 0, 0),
                                localScale = new Vector3(1, 1, 1),
                                limbMask = LimbFlags.None
                            }
                    }
                }
            });

            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            ItemDisplayRuleSet.NamedRuleGroup[] value = list.ToArray();
            ItemDisplayRuleSet.NamedRuleGroup[] value2 = list2.ToArray();
            typeof(ItemDisplayRuleSet).GetField("namedItemRuleGroups", bindingAttr).SetValue(itemDisplayRuleSet, value);
            typeof(ItemDisplayRuleSet).GetField("namedEquipmentRuleGroups", bindingAttr).SetValue(itemDisplayRuleSet, value2);

            characterModel.itemDisplayRuleSet = itemDisplayRuleSet;
        }*/

        public static GameObject LoadDisplay(string name)
        {
            if (itemDisplayPrefabs.ContainsKey(name.ToLower()))
            {
                if (itemDisplayPrefabs[name.ToLower()]) return itemDisplayPrefabs[name.ToLower()];
            }
            return null;
        }

        private static void PopulateDisplays()
        {
            ItemDisplayRuleSet itemDisplayRuleSet = Resources.Load<GameObject>("Prefabs/CharacterBodies/CommandoBody").GetComponent<ModelLocator>().modelTransform.GetComponent<CharacterModel>().itemDisplayRuleSet;

            EnforcerPlugin.bungusMat = itemDisplayRuleSet.FindItemDisplayRuleGroup("Mushroom").rules[0].followerPrefab.GetComponentInChildren<SkinnedMeshRenderer>().material;

            capacitorPrefab = PrefabAPI.InstantiateClone(itemDisplayRuleSet.FindEquipmentDisplayRuleGroup("Lightning").rules[0].followerPrefab, "DisplayEnforcerLightning", true);
            capacitorPrefab.AddComponent<UnityEngine.Networking.NetworkIdentity>();

            var limbMatcher = capacitorPrefab.GetComponent<LimbMatcher>();

            limbMatcher.limbPairs[0].targetChildLimb = "ShoulderL";
            limbMatcher.limbPairs[1].targetChildLimb = "ElbowL";
            limbMatcher.limbPairs[2].targetChildLimb = "HandL";

            gatDronePrefab = PrefabAPI.InstantiateClone(itemDisplayRuleSet.FindEquipmentDisplayRuleGroup("GoldGat").rules[0].followerPrefab, "DisplayEnforcerGatDrone", false);

            GameObject gatDrone = PrefabAPI.InstantiateClone(Assets.gatDrone, "GatDrone", false);

            Material gatMaterial = gatDrone.GetComponentInChildren<MeshRenderer>().material;
            Material newMaterial = UnityEngine.Object.Instantiate<Material>(Resources.Load<GameObject>("Prefabs/CharacterBodies/CommandoBody").GetComponentInChildren<CharacterModel>().baseRendererInfos[0].defaultMaterial);

            newMaterial.SetColor("_Color", gatMaterial.GetColor("_Color"));
            newMaterial.SetTexture("_MainTex", gatMaterial.GetTexture("_MainTex"));
            newMaterial.SetFloat("_EmPower", 0f);
            newMaterial.SetColor("_EmColor", Color.black);
            newMaterial.SetFloat("_NormalStrength", 0);

            gatDrone.transform.parent = gatDronePrefab.transform;
            gatDrone.transform.localPosition = new Vector3(-0.025f, -3.1f, 0);
            gatDrone.transform.localRotation = Quaternion.Euler(new Vector3(-90, 90, 0));
            gatDrone.transform.localScale = new Vector3(175, 175, 175);

            CharacterModel.RendererInfo[] infos = gatDronePrefab.GetComponent<ItemDisplay>().rendererInfos;
            CharacterModel.RendererInfo[] newInfos = new CharacterModel.RendererInfo[]
            {
                infos[0],
                new CharacterModel.RendererInfo
                {
                    renderer = gatDrone.GetComponentInChildren<MeshRenderer>(),
                    defaultMaterial = newMaterial,
                    defaultShadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On,
                    ignoreOverlays = false
                }
            };

            gatDronePrefab.GetComponent<ItemDisplay>().rendererInfos = newInfos;

            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            ItemDisplayRuleSet.NamedRuleGroup[] array = typeof(ItemDisplayRuleSet).GetField("namedItemRuleGroups", bindingAttr).GetValue(itemDisplayRuleSet) as ItemDisplayRuleSet.NamedRuleGroup[];
            ItemDisplayRuleSet.NamedRuleGroup[] array2 = typeof(ItemDisplayRuleSet).GetField("namedEquipmentRuleGroups", bindingAttr).GetValue(itemDisplayRuleSet) as ItemDisplayRuleSet.NamedRuleGroup[];
            ItemDisplayRuleSet.NamedRuleGroup[] array3 = array;

            for (int i = 0; i < array3.Length; i++)
            {
                ItemDisplayRule[] rules = array3[i].displayRuleGroup.rules;
                for (int j = 0; j < rules.Length; j++)
                {
                    GameObject followerPrefab = rules[j].followerPrefab;
                    if (!(followerPrefab == null))
                    {
                        string name = followerPrefab.name;
                        string key = (name != null) ? name.ToLower() : null;
                        if (!itemDisplayPrefabs.ContainsKey(key))
                        {
                            itemDisplayPrefabs[key] = followerPrefab;
                        }
                    }
                }
            }

            array3 = array2;
            for (int i = 0; i < array3.Length; i++)
            {
                ItemDisplayRule[] rules = array3[i].displayRuleGroup.rules;
                for (int j = 0; j < rules.Length; j++)
                {
                    GameObject followerPrefab2 = rules[j].followerPrefab;
                    if (!(followerPrefab2 == null))
                    {
                        string name2 = followerPrefab2.name;
                        string key2 = (name2 != null) ? name2.ToLower() : null;
                        if (!itemDisplayPrefabs.ContainsKey(key2))
                        {
                            itemDisplayPrefabs[key2] = followerPrefab2;
                        }
                    }
                }
            }
        }




        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static GameObject LoadAetheriumDisplay(string name)
        {
            switch (name)
            {
                case "AccursedPotion":
                    return Aetherium.Items.AccursedPotion.ItemBodyModelPrefab;
                case "AlienMagnet":
                    return Aetherium.Items.AlienMagnet.ItemBodyModelPrefab;
                case "BlasterSword":
                    return Aetherium.Items.BlasterSword.ItemBodyModelPrefab;
                case "BloodSoakedShield":
                    return Aetherium.Items.BloodSoakedShield.ItemBodyModelPrefab;
                case "FeatheredPlume":
                    return Aetherium.Items.FeatheredPlume.ItemBodyModelPrefab;
                case "InspiringDrone":
                    return Aetherium.Items.InspiringDrone.ItemFollowerPrefab;
                case "SharkTeeth":
                    return Aetherium.Items.SharkTeeth.ItemBodyModelPrefab;
                case "ShieldingCore":
                    return Aetherium.Items.ShieldingCore.ItemBodyModelPrefab;
                case "UnstableDesign":
                    return Aetherium.Items.UnstableDesign.ItemBodyModelPrefab;
                case "VoidHeart":
                    return Aetherium.Items.Voidheart.ItemBodyModelPrefab;
                case "WeightedAnklet":
                    return Aetherium.Items.WeightedAnklet.ItemBodyModelPrefab;
                case "WitchesRing":
                    return Aetherium.Items.WitchesRing.ItemBodyModelPrefab;
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static GameObject LoadSivDisplay(string name)
        {
            switch (name)
            {
                case "BeetlePlush":
                    return SivsItemsRoR2.BeetlePlush.displayPrefab;
                case "BisonShield":
                    return SivsItemsRoR2.BisonShield.displayPrefab;
                case "FlameGland":
                    return SivsItemsRoR2.FlameGland.displayPrefab;
                case "Geode":
                    return SivsItemsRoR2.Geode.displayPrefab;
                case "ImpEye":
                    return SivsItemsRoR2.ImpEye.displayPrefab;
                case "NullSeed":
                    return SivsItemsRoR2.NullSeed.displayPrefab;
                case "Tarbine":
                    return SivsItemsRoR2.Tarbine.displayPrefab;
                case "Tentacle":
                    return SivsItemsRoR2.Tentacle.displayPrefab;
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        public static GameObject LoadSupplyDropDisplay(string name)
        {
            switch (name)
            {
                case "BloodBook":
                    return SupplyDrop.Items.BloodBook.ItemBodyModelPrefab;
                case "ElectroPlankton":
                    return SupplyDrop.Items.ElectroPlankton.ItemBodyModelPrefab;
                case "HardenedBoneFragments":
                    return SupplyDrop.Items.HardenedBoneFragments.ItemBodyModelPrefab;
                case "QSGen":
                    return SupplyDrop.Items.QSGen.ItemBodyModelPrefab;
                case "SalvagedWires":
                    return SupplyDrop.Items.SalvagedWires.ItemBodyModelPrefab;
                case "ShellPlating":
                    return SupplyDrop.Items.ShellPlating.ItemBodyModelPrefab;
                case "UnassumingTie":
                    return SupplyDrop.Items.UnassumingTie.ItemBodyModelPrefab;
            }
            return null;
        }
    }
}
