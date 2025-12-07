# C#スクリプト仕様書
**作成日:** 2025/12/08 06:10

---

## フォルダ一覧 (概要)
| フォルダ | ファイル数 | 総行数 | コード行数 | クラス数 |
| :--- | :---: | :---: | :---: | :---: |
| [Assets/Fantasy Backgrouds #1/Scripts](#folder-assetsfantasybackgrouds1scripts) | 1 | 50 | 45 | 1 |
| [Assets/Free UI build package/Script](#folder-assetsfreeuibuildpackagescript) | 2 | 51 | 37 | 2 |
| [Assets/Photon/PhotonChat/Code](#folder-assetsphotonphotonchatcode) | 13 | 3102 | 1905 | 10 |
| [Assets/Photon/PhotonChat/Demos/Common](#folder-assetsphotonphotonchatdemoscommon) | 4 | 220 | 113 | 4 |
| [Assets/Photon/PhotonChat/Demos/DemoChat](#folder-assetsphotonphotonchatdemosdemochat) | 7 | 949 | 686 | 7 |
| [Assets/Photon/PhotonLibs/WebSocket](#folder-assetsphotonphotonlibswebsocket) | 2 | 687 | 497 | 0 |
| [Assets/Photon/PhotonRealtime/Code](#folder-assetsphotonphotonrealtimecode) | 17 | 11497 | 6454 | 14 |
| [Assets/Photon/PhotonRealtime/Code/Unity](#folder-assetsphotonphotonrealtimecodeunity) | 1 | 116 | 73 | 0 |
| [Assets/Photon/PhotonRealtime/Demos/DemoLoadBalancing](#folder-assetsphotonphotonrealtimedemosdemoloadbalancing) | 1 | 145 | 109 | 1 |
| [Assets/Photon/PhotonUnityNetworking/Code](#folder-assetsphotonphotonunitynetworkingcode) | 9 | 8567 | 4990 | 6 |
| [Assets/Photon/PhotonUnityNetworking/Code/Interfaces](#folder-assetsphotonphotonunitynetworkingcodeinterfaces) | 2 | 192 | 43 | 0 |
| [Assets/Photon/PhotonUnityNetworking/Code/Utilities](#folder-assetsphotonphotonunitynetworkingcodeutilities) | 1 | 494 | 292 | 1 |
| [Assets/Photon/PhotonUnityNetworking/Code/Views](#folder-assetsphotonphotonunitynetworkingcodeviews) | 5 | 1546 | 1111 | 5 |
| [Assets/Photon/PhotonUnityNetworking/Demos](#folder-assetsphotonphotonunitynetworkingdemos) | 1 | 111 | 84 | 1 |
| [Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts](#folder-assetsphotonphotonunitynetworkingdemosdemoasteroidsscripts) | 1 | 35 | 29 | 1 |
| [Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Game](#folder-assetsphotonphotonunitynetworkingdemosdemoasteroidsscriptsgame) | 5 | 712 | 503 | 5 |
| [Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Lobby](#folder-assetsphotonphotonunitynetworkingdemosdemoasteroidsscriptslobby) | 4 | 526 | 406 | 4 |
| [Assets/Photon/PhotonUnityNetworking/Demos/DemoHub/Scripts](#folder-assetsphotonphotonunitynetworkingdemosdemohubscripts) | 2 | 281 | 202 | 2 |
| [Assets/Photon/PhotonUnityNetworking/Demos/DemoProcedural/Scripts](#folder-assetsphotonphotonunitynetworkingdemosdemoproceduralscripts) | 6 | 1227 | 849 | 6 |
| [Assets/Photon/PhotonUnityNetworking/Demos/DemoSlotRacer/Scripts](#folder-assetsphotonphotonunitynetworkingdemosdemoslotracerscripts) | 3 | 366 | 199 | 3 |
| [Assets/Photon/PhotonUnityNetworking/Demos/DemoSlotRacer/Scripts/BezierCurve](#folder-assetsphotonphotonunitynetworkingdemosdemoslotracerscriptsbeziercurve) | 7 | 592 | 418 | 6 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunBasics-Tutorial/Scripts](#folder-assetsphotonphotonunitynetworkingdemospunbasicstutorialscripts) | 8 | 1249 | 656 | 8 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit](#folder-assetsphotonphotonunitynetworkingdemospuncockpit) | 1 | 807 | 560 | 1 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Forms](#folder-assetsphotonphotonunitynetworkingdemospuncockpitforms) | 5 | 276 | 174 | 5 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscripts) | 2 | 66 | 33 | 2 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Autonomous UI](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsautonomousui) | 10 | 565 | 369 | 10 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Autonomous UI/CurrentRoom](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsautonomousuicurrentroom) | 2 | 131 | 86 | 2 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Autonomous UI/Generic](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsautonomousuigeneric) | 4 | 231 | 154 | 4 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Controllers](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptscontrollers) | 1 | 239 | 162 | 1 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Lists](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptslists) | 9 | 1038 | 682 | 9 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/PropertyFields](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptspropertyfields) | 1 | 71 | 49 | 1 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/ReadOnlyProperties](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsreadonlyproperties) | 27 | 1108 | 718 | 27 |
| [Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/ThirdParty](#folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsthirdparty) | 1 | 102 | 55 | 1 |
| [Assets/Photon/PhotonUnityNetworking/Demos/Shared Assets/Scripts](#folder-assetsphotonphotonunitynetworkingdemossharedassetsscripts) | 3 | 459 | 289 | 3 |
| [Assets/Photon/PhotonUnityNetworking/UtilityScripts/Culling](#folder-assetsphotonphotonunitynetworkingutilityscriptsculling) | 2 | 755 | 440 | 2 |
| [Assets/Photon/PhotonUnityNetworking/UtilityScripts/Debugging](#folder-assetsphotonphotonunitynetworkingutilityscriptsdebugging) | 4 | 575 | 413 | 4 |
| [Assets/Photon/PhotonUnityNetworking/UtilityScripts/PhotonPlayer](#folder-assetsphotonphotonunitynetworkingutilityscriptsphotonplayer) | 4 | 1113 | 737 | 4 |
| [Assets/Photon/PhotonUnityNetworking/UtilityScripts/PhotonView](#folder-assetsphotonphotonunitynetworkingutilityscriptsphotonview) | 1 | 72 | 50 | 1 |
| [Assets/Photon/PhotonUnityNetworking/UtilityScripts/Prototyping](#folder-assetsphotonphotonunitynetworkingutilityscriptsprototyping) | 8 | 972 | 565 | 8 |
| [Assets/Photon/PhotonUnityNetworking/UtilityScripts/Room](#folder-assetsphotonphotonunitynetworkingutilityscriptsroom) | 1 | 176 | 101 | 1 |
| [Assets/Photon/PhotonUnityNetworking/UtilityScripts/TurnBased](#folder-assetsphotonphotonunitynetworkingutilityscriptsturnbased) | 1 | 430 | 206 | 1 |
| [Assets/Photon/PhotonUnityNetworking/UtilityScripts/UI](#folder-assetsphotonphotonunitynetworkingutilityscriptsui) | 7 | 481 | 263 | 7 |
| [Assets/Plugins/Demigiant/DOTween/Modules](#folder-assetspluginsdemigiantdotweenmodules) | 8 | 2072 | 1295 | 7 |
| [Assets/Plugins/Demigiant/DOTweenPro](#folder-assetspluginsdemigiantdotweenpro) | 6 | 2315 | 1570 | 2 |
| [Assets/Scripts](#folder-assetsscripts) | 41 | 6491 | 4301 | 41 |
| [Assets/TextMesh Pro/Examples & Extras/Scripts](#folder-assetstextmeshproexamplesextrasscripts) | 34 | 4964 | 3123 | 34 |

## ファイル一覧
<a id='folder-assetsfantasybackgrouds1scripts'></a>
### Folder: Assets/Fantasy Backgrouds #1/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [CameraController.cs](files/CameraController_cs.md) | 50 | 45 | 0 | [`C:CameraController`](files/CameraController_cs.md#CameraController)  |

<a id='folder-assetsfreeuibuildpackagescript'></a>
### Folder: Assets/Free UI build package/Script
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [Slide.cs](files/Slide_cs.md) | 20 | 14 | 2 | [`C:Slide`](files/Slide_cs.md#Slide)  |
| [Togglescript.cs](files/Togglescript_cs.md) | 31 | 23 | 0 | [`C:Togglescript`](files/Togglescript_cs.md#Togglescript)  |

<a id='folder-assetsphotonphotonchatcode'></a>
### Folder: Assets/Photon/PhotonChat/Code
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [ChannelCreationOptions.cs](files/ChannelCreationOptions_cs.md) | 23 | 12 | 8 | [`C:ChannelCreationOptions`](files/ChannelCreationOptions_cs.md#ChannelCreationOptions)  |
| [ChannelWellKnownProperties.cs](files/ChannelWellKnownProperties_cs.md) | 15 | 8 | 5 | [`C:ChannelWellKnownProperties`](files/ChannelWellKnownProperties_cs.md#ChannelWellKnownProperties)  |
| [ChatAppSettings.cs](files/ChatAppSettings_cs.md) | 64 | 27 | 24 | [`C:ChatAppSettings`](files/ChatAppSettings_cs.md#ChatAppSettings)  |
| [ChatChannel.cs](files/ChatChannel_cs.md) | 255 | 185 | 36 | [`C:ChatChannel`](files/ChatChannel_cs.md#ChatChannel)  |
| [ChatClient.cs](files/ChatClient_cs.md) | 1861 | 1306 | 378 | [`C:ChatClient`](files/ChatClient_cs.md#ChatClient)  |
| [ChatDisconnectCause.cs](files/ChatDisconnectCause_cs.md) | 43 | 20 | 21 |  |
| [ChatEventCode.cs](files/ChatEventCode_cs.md) | 40 | 17 | 20 | [`C:ChatEventCode`](files/ChatEventCode_cs.md#ChatEventCode)  |
| [ChatOperationCode.cs](files/ChatOperationCode_cs.md) | 38 | 16 | 18 | [`C:ChatOperationCode`](files/ChatOperationCode_cs.md#ChatOperationCode)  |
| [ChatParameterCode.cs](files/ChatParameterCode_cs.md) | 85 | 31 | 47 | [`C:ChatParameterCode`](files/ChatParameterCode_cs.md#ChatParameterCode)  |
| [ChatPeer.cs](files/ChatPeer_cs.md) | 455 | 224 | 156 | [`C:ChatPeer`](files/ChatPeer_cs.md#ChatPeer)  |
| [ChatState.cs](files/ChatState_cs.md) | 39 | 19 | 19 |  |
| [ChatUserStatus.cs](files/ChatUserStatus_cs.md) | 36 | 13 | 21 | [`C:ChatUserStatus`](files/ChatUserStatus_cs.md#ChatUserStatus)  |
| [IChatClientListener.cs](files/IChatClientListener_cs.md) | 148 | 27 | 99 |  |

<a id='folder-assetsphotonphotonchatdemoscommon'></a>
### Folder: Assets/Photon/PhotonChat/Demos/Common
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [EventSystemSpawner.cs](files/EventSystemSpawner_cs.md) | 40 | 23 | 13 | [`C:EventSystemSpawner`](files/EventSystemSpawner_cs.md#EventSystemSpawner)  |
| [OnStartDelete.cs](files/OnStartDelete_cs.md) | 24 | 11 | 11 | [`C:OnStartDelete`](files/OnStartDelete_cs.md#OnStartDelete)  |
| [TextButtonTransition.cs](files/TextButtonTransition_cs.md) | 70 | 38 | 20 | [`C:TextButtonTransition`](files/TextButtonTransition_cs.md#TextButtonTransition)  |
| [TextToggleIsOnTransition.cs](files/TextToggleIsOnTransition_cs.md) | 86 | 41 | 26 | [`C:TextToggleIsOnTransition`](files/TextToggleIsOnTransition_cs.md#TextToggleIsOnTransition)  |

<a id='folder-assetsphotonphotonchatdemosdemochat'></a>
### Folder: Assets/Photon/PhotonChat/Demos/DemoChat
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [AppSettingsExtensions.cs](files/AppSettingsExtensions_cs.md) | 33 | 22 | 7 | [`C:AppSettingsExtensions`](files/AppSettingsExtensions_cs.md#AppSettingsExtensions)  |
| [ChannelSelector.cs](files/ChannelSelector_cs.md) | 32 | 21 | 5 | [`C:ChannelSelector`](files/ChannelSelector_cs.md#ChannelSelector)  |
| [ChatAppIdCheckerUI.cs](files/ChatAppIdCheckerUI_cs.md) | 60 | 41 | 9 | [`C:ChatAppIdCheckerUI`](files/ChatAppIdCheckerUI_cs.md#ChatAppIdCheckerUI)  |
| [ChatGui.cs](files/ChatGui_cs.md) | 665 | 492 | 53 | [`C:ChatGui`](files/ChatGui_cs.md#ChatGui)  |
| [FriendItem.cs](files/FriendItem_cs.md) | 84 | 63 | 10 | [`C:FriendItem`](files/FriendItem_cs.md#FriendItem)  |
| [IgnoreUiRaycastWhenInactive.cs](files/IgnoreUiRaycastWhenInactive_cs.md) | 20 | 11 | 5 | [`C:IgnoreUiRaycastWhenInactive`](files/IgnoreUiRaycastWhenInactive_cs.md#IgnoreUiRaycastWhenInactive)  |
| [NamePickGui.cs](files/NamePickGui_cs.md) | 55 | 36 | 6 | [`C:NamePickGui`](files/NamePickGui_cs.md#NamePickGui)  |

<a id='folder-assetsphotonphotonlibswebsocket'></a>
### Folder: Assets/Photon/PhotonLibs/WebSocket
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [SocketWebTcp.cs](files/SocketWebTcp_cs.md) | 435 | 306 | 53 |  |
| [WebSocket.cs](files/WebSocket_cs.md) | 252 | 191 | 13 |  |

<a id='folder-assetsphotonphotonrealtimecode'></a>
### Folder: Assets/Photon/PhotonRealtime/Code
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [AppSettings.cs](files/AppSettings_cs.md) | 199 | 112 | 54 | [`C:AppSettings`](files/AppSettings_cs.md#AppSettings)  |
| [ConnectionHandler.cs](files/ConnectionHandler_cs.md) | 266 | 180 | 39 | [`C:ConnectionHandler`](files/ConnectionHandler_cs.md#ConnectionHandler)  |
| [CustomTypesUnity.cs](files/CustomTypesUnity_cs.md) | 167 | 122 | 14 | [`C:CustomTypesUnity`](files/CustomTypesUnity_cs.md#CustomTypesUnity)  |
| [Extensions.cs](files/Extensions_cs.md) | 270 | 155 | 80 | [`C:Extensions`](files/Extensions_cs.md#Extensions)  |
| [FriendInfo.cs](files/FriendInfo_cs.md) | 49 | 27 | 12 | [`C:FriendInfo`](files/FriendInfo_cs.md#FriendInfo)  |
| [LoadBalancingClient.cs](files/LoadBalancingClient_cs.md) | 4577 | 2446 | 1512 | [`C:LoadBalancingClient`](files/LoadBalancingClient_cs.md#LoadBalancingClient)  |
| [LoadbalancingPeer.cs](files/LoadbalancingPeer_cs.md) | 2293 | 1107 | 778 |  |
| [PhotonPing.cs](files/PhotonPing_cs.md) | 503 | 375 | 48 | [`C:PhotonPing`](files/PhotonPing_cs.md#PhotonPing)  |
| [PhotonPingClasses.cs](files/PhotonPingClasses_cs.md) | 1 | 0 | 1 |  |
| [Player.cs](files/Player_cs.md) | 452 | 230 | 164 | [`C:Player`](files/Player_cs.md#Player)  |
| [Region.cs](files/Region_cs.md) | 95 | 63 | 15 | [`C:Region`](files/Region_cs.md#Region)  |
| [RegionHandler.cs](files/RegionHandler_cs.md) | 853 | 583 | 126 | [`C:RegionHandler`](files/RegionHandler_cs.md#RegionHandler)  |
| [Room.cs](files/Room_cs.md) | 633 | 327 | 238 | [`C:Room`](files/Room_cs.md#Room)  |
| [RoomInfo.cs](files/RoomInfo_cs.md) | 281 | 147 | 89 | [`C:RoomInfo`](files/RoomInfo_cs.md#RoomInfo)  |
| [SupportLogger.cs](files/SupportLogger_cs.md) | 434 | 332 | 31 | [`C:SupportLogger`](files/SupportLogger_cs.md#SupportLogger)  |
| [SystemConnectionSummary.cs](files/SystemConnectionSummary_cs.md) | 236 | 125 | 70 | [`C:SystemConnectionSummary`](files/SystemConnectionSummary_cs.md#SystemConnectionSummary)  |
| [WebRpc.cs](files/WebRpc_cs.md) | 188 | 123 | 44 |  |

<a id='folder-assetsphotonphotonrealtimecodeunity'></a>
### Folder: Assets/Photon/PhotonRealtime/Code/Unity
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PhotonAppSettings.cs](files/PhotonAppSettings_cs.md) | 116 | 73 | 20 |  |

<a id='folder-assetsphotonphotonrealtimedemosdemoloadbalancing'></a>
### Folder: Assets/Photon/PhotonRealtime/Demos/DemoLoadBalancing
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [ConnectAndJoinRandomLb.cs](files/ConnectAndJoinRandomLb_cs.md) | 145 | 109 | 7 | [`C:ConnectAndJoinRandomLb`](files/ConnectAndJoinRandomLb_cs.md#ConnectAndJoinRandomLb)  |

<a id='folder-assetsphotonphotonunitynetworkingcode'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Code
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [CustomTypes.cs](files/CustomTypes_cs.md) | 74 | 48 | 13 | [`C:CustomTypes`](files/CustomTypes_cs.md#CustomTypes)  |
| [Enums.cs](files/Enums_cs.md) | 94 | 27 | 49 |  |
| [PhotonHandler.cs](files/PhotonHandler_cs.md) | 412 | 285 | 52 | [`C:PhotonHandler`](files/PhotonHandler_cs.md#PhotonHandler)  |
| [PhotonNetwork.cs](files/PhotonNetwork_cs.md) | 3314 | 1694 | 1230 | [`C:PhotonNetwork`](files/PhotonNetwork_cs.md#PhotonNetwork)  |
| [PhotonNetworkPart.cs](files/PhotonNetworkPart_cs.md) | 2576 | 1765 | 420 |  |
| [PhotonStreamQueue.cs](files/PhotonStreamQueue_cs.md) | 197 | 116 | 49 | [`C:PhotonStreamQueue`](files/PhotonStreamQueue_cs.md#PhotonStreamQueue)  |
| [PhotonView.cs](files/PhotonView_cs.md) | 826 | 472 | 224 | [`C:PhotonView`](files/PhotonView_cs.md#PhotonView)  |
| [PunClasses.cs](files/PunClasses_cs.md) | 974 | 521 | 348 |  |
| [ServerSettings.cs](files/ServerSettings_cs.md) | 100 | 62 | 23 | [`C:ServerSettings`](files/ServerSettings_cs.md#ServerSettings)  |

<a id='folder-assetsphotonphotonunitynetworkingcodeinterfaces'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Code/Interfaces
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [IPhotonViewCallbacks.cs](files/IPhotonViewCallbacks_cs.md) | 51 | 19 | 26 |  |
| [IPunCallbacks.cs](files/IPunCallbacks_cs.md) | 141 | 24 | 107 |  |

<a id='folder-assetsphotonphotonunitynetworkingcodeutilities'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Code/Utilities
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [NestedComponentUtilities.cs](files/NestedComponentUtilities_cs.md) | 494 | 292 | 100 | [`C:NestedComponentUtilities`](files/NestedComponentUtilities_cs.md#NestedComponentUtilities)  |

<a id='folder-assetsphotonphotonunitynetworkingcodeviews'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Code/Views
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PhotonAnimatorView.cs](files/PhotonAnimatorView_cs.md) | 572 | 408 | 68 | [`C:PhotonAnimatorView`](files/PhotonAnimatorView_cs.md#PhotonAnimatorView)  |
| [PhotonRigidbody2DView.cs](files/PhotonRigidbody2DView_cs.md) | 111 | 79 | 9 | [`C:PhotonRigidbody2DView`](files/PhotonRigidbody2DView_cs.md#PhotonRigidbody2DView)  |
| [PhotonRigidbodyView.cs](files/PhotonRigidbodyView_cs.md) | 112 | 80 | 9 | [`C:PhotonRigidbodyView`](files/PhotonRigidbodyView_cs.md#PhotonRigidbodyView)  |
| [PhotonTransformView.cs](files/PhotonTransformView_cs.md) | 194 | 155 | 12 | [`C:PhotonTransformView`](files/PhotonTransformView_cs.md#PhotonTransformView)  |
| [PhotonTransformViewClassic.cs](files/PhotonTransformViewClassic_cs.md) | 557 | 389 | 70 | [`C:PhotonTransformViewClassic`](files/PhotonTransformViewClassic_cs.md#PhotonTransformViewClassic)  |

<a id='folder-assetsphotonphotonunitynetworkingdemos'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [WebRpcImplementationExample.cs](files/WebRpcImplementationExample_cs.md) | 111 | 84 | 19 | [`C:WebRpcImplementationExample`](files/WebRpcImplementationExample_cs.md#WebRpcImplementationExample)  |

<a id='folder-assetsphotonphotonunitynetworkingdemosdemoasteroidsscripts'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [AsteroidsGame.cs](files/AsteroidsGame_cs.md) | 35 | 29 | 0 | [`C:AsteroidsGame`](files/AsteroidsGame_cs.md#AsteroidsGame)  |

<a id='folder-assetsphotonphotonunitynetworkingdemosdemoasteroidsscriptsgame'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Game
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [Asteroid.cs](files/Asteroid_cs.md) | 123 | 88 | 10 | [`C:Asteroid`](files/Asteroid_cs.md#Asteroid)  |
| [AsteroidsGameManager.cs](files/AsteroidsGameManager_cs.md) | 267 | 192 | 17 | [`C:AsteroidsGameManager`](files/AsteroidsGameManager_cs.md#AsteroidsGameManager)  |
| [Bullet.cs](files/Bullet_cs.md) | 31 | 25 | 0 | [`C:Bullet`](files/Bullet_cs.md#Bullet)  |
| [PlayerOverviewPanel.cs](files/PlayerOverviewPanel_cs.md) | 71 | 48 | 9 | [`C:PlayerOverviewPanel`](files/PlayerOverviewPanel_cs.md#PlayerOverviewPanel)  |
| [Spaceship.cs](files/Spaceship_cs.md) | 220 | 150 | 20 | [`C:Spaceship`](files/Spaceship_cs.md#Spaceship)  |

<a id='folder-assetsphotonphotonunitynetworkingdemosdemoasteroidsscriptslobby'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/DemoAsteroids/Scripts/Lobby
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [LobbyMainPanel.cs](files/LobbyMainPanel_cs.md) | 372 | 288 | 6 | [`C:LobbyMainPanel`](files/LobbyMainPanel_cs.md#LobbyMainPanel)  |
| [LobbyTopPanel.cs](files/LobbyTopPanel_cs.md) | 22 | 17 | 0 | [`C:LobbyTopPanel`](files/LobbyTopPanel_cs.md#LobbyTopPanel)  |
| [PlayerListEntry.cs](files/PlayerListEntry_cs.md) | 97 | 72 | 9 | [`C:PlayerListEntry`](files/PlayerListEntry_cs.md#PlayerListEntry)  |
| [RoomListEntry.cs](files/RoomListEntry_cs.md) | 35 | 29 | 0 | [`C:RoomListEntry`](files/RoomListEntry_cs.md#RoomListEntry)  |

<a id='folder-assetsphotonphotonunitynetworkingdemosdemohubscripts'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/DemoHub/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [DemoHubManager.cs](files/DemoHubManager_cs.md) | 188 | 144 | 11 | [`C:DemoHubManager`](files/DemoHubManager_cs.md#DemoHubManager)  |
| [ToDemoHubButton.cs](files/ToDemoHubButton_cs.md) | 93 | 58 | 13 | [`C:ToDemoHubButton`](files/ToDemoHubButton_cs.md#ToDemoHubButton)  |

<a id='folder-assetsphotonphotonunitynetworkingdemosdemoproceduralscripts'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/DemoProcedural/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [Block.cs](files/Block_cs.md) | 14 | 9 | 4 | [`C:Block`](files/Block_cs.md#Block)  |
| [Cluster.cs](files/Cluster_cs.md) | 178 | 100 | 42 | [`C:Cluster`](files/Cluster_cs.md#Cluster)  |
| [IngameControlPanel.cs](files/IngameControlPanel_cs.md) | 270 | 220 | 29 | [`C:IngameControlPanel`](files/IngameControlPanel_cs.md#IngameControlPanel)  |
| [Noise.cs](files/Noise_cs.md) | 393 | 273 | 66 | [`C:Noise`](files/Noise_cs.md#Noise)  |
| [ProceduralController.cs](files/ProceduralController_cs.md) | 83 | 63 | 9 | [`C:ProceduralController`](files/ProceduralController_cs.md#ProceduralController)  |
| [WorldGenerator.cs](files/WorldGenerator_cs.md) | 289 | 184 | 48 | [`C:WorldGenerator`](files/WorldGenerator_cs.md#WorldGenerator)  |

<a id='folder-assetsphotonphotonunitynetworkingdemosdemoslotracerscripts'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/DemoSlotRacer/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PlayerControl.cs](files/PlayerControl_cs.md) | 232 | 116 | 72 | [`C:PlayerControl`](files/PlayerControl_cs.md#PlayerControl)  |
| [SlotLanes.cs](files/SlotLanes_cs.md) | 38 | 13 | 19 | [`C:SlotLanes`](files/SlotLanes_cs.md#SlotLanes)  |
| [SlotRacerSplashScreen.cs](files/SlotRacerSplashScreen_cs.md) | 96 | 70 | 13 | [`C:SlotRacerSplashScreen`](files/SlotRacerSplashScreen_cs.md#SlotRacerSplashScreen)  |

<a id='folder-assetsphotonphotonunitynetworkingdemosdemoslotracerscriptsbeziercurve'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/DemoSlotRacer/Scripts/BezierCurve
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [Bezier.cs](files/Bezier_cs.md) | 56 | 41 | 10 | [`C:Bezier`](files/Bezier_cs.md#Bezier)  |
| [BezierControlPointMode.cs](files/BezierControlPointMode_cs.md) | 19 | 8 | 10 |  |
| [BezierCurve.cs](files/BezierCurve_cs.md) | 45 | 29 | 10 | [`C:BezierCurve`](files/BezierCurve_cs.md#BezierCurve)  |
| [BezierSpline.cs](files/BezierSpline_cs.md) | 332 | 263 | 22 | [`C:BezierSpline`](files/BezierSpline_cs.md#BezierSpline)  |
| [Line.cs](files/Line_cs.md) | 19 | 7 | 10 | [`C:Line`](files/Line_cs.md#Line)  |
| [SplinePosition.cs](files/SplinePosition_cs.md) | 57 | 34 | 11 | [`C:SplinePosition`](files/SplinePosition_cs.md#SplinePosition)  |
| [SplineWalker.cs](files/SplineWalker_cs.md) | 64 | 36 | 13 | [`C:SplineWalker`](files/SplineWalker_cs.md#SplineWalker)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospunbasicstutorialscripts'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunBasics-Tutorial/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [CameraWork.cs](files/CameraWork_cs.md) | 130 | 70 | 30 | [`C:CameraWork`](files/CameraWork_cs.md#CameraWork)  |
| [GameManager.cs](files/GameManager_cs.md) | 188 | 102 | 38 | [`C:GameManager`](files/GameManager_cs.md#GameManager)  |
| [Launcher.cs](files/Launcher_cs.md) | 226 | 101 | 77 | [`C:Launcher`](files/Launcher_cs.md#Launcher)  |
| [LoaderAnime.cs](files/LoaderAnime_cs.md) | 107 | 51 | 33 | [`C:LoaderAnime`](files/LoaderAnime_cs.md#LoaderAnime)  |
| [PlayerAnimatorManager.cs](files/PlayerAnimatorManager_cs.md) | 81 | 42 | 23 | [`C:PlayerAnimatorManager`](files/PlayerAnimatorManager_cs.md#PlayerAnimatorManager)  |
| [PlayerManager.cs](files/PlayerManager_cs.md) | 295 | 178 | 67 | [`C:PlayerManager`](files/PlayerManager_cs.md#PlayerManager)  |
| [PlayerNameInputField.cs](files/PlayerNameInputField_cs.md) | 75 | 39 | 21 | [`C:PlayerNameInputField`](files/PlayerNameInputField_cs.md#PlayerNameInputField)  |
| [PlayerUI.cs](files/PlayerUI_cs.md) | 147 | 73 | 35 | [`C:PlayerUI`](files/PlayerUI_cs.md#PlayerUI)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpit'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PunCockpit.cs](files/PunCockpit_cs.md) | 807 | 560 | 38 | [`C:PunCockpit`](files/PunCockpit_cs.md#PunCockpit)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitforms'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Forms
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [ConnectToRegionUIForm.cs](files/ConnectToRegionUIForm_cs.md) | 57 | 36 | 10 | [`C:ConnectToRegionUIForm`](files/ConnectToRegionUIForm_cs.md#ConnectToRegionUIForm)  |
| [CreateRoomUiForm.cs](files/CreateRoomUiForm_cs.md) | 71 | 48 | 10 | [`C:CreateRoomUiForm`](files/CreateRoomUiForm_cs.md#CreateRoomUiForm)  |
| [LoadLevelUIForm.cs](files/LoadLevelUIForm_cs.md) | 47 | 28 | 10 | [`C:LoadLevelUIForm`](files/LoadLevelUIForm_cs.md#LoadLevelUIForm)  |
| [SetRoomCustomPropertyUIForm.cs](files/SetRoomCustomPropertyUIForm_cs.md) | 47 | 28 | 10 | [`C:SetRoomCustomPropertyUIForm`](files/SetRoomCustomPropertyUIForm_cs.md#SetRoomCustomPropertyUIForm)  |
| [UserIdUiForm.cs](files/UserIdUiForm_cs.md) | 54 | 34 | 10 | [`C:UserIdUiForm`](files/UserIdUiForm_cs.md#UserIdUiForm)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscripts'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [InfosPanelPlaceholder.cs](files/InfosPanelPlaceholder_cs.md) | 25 | 12 | 9 | [`C:InfosPanelPlaceholder`](files/InfosPanelPlaceholder_cs.md#InfosPanelPlaceholder)  |
| [ScoreHelper.cs](files/ScoreHelper_cs.md) | 41 | 21 | 7 | [`C:ScoreHelper`](files/ScoreHelper_cs.md#ScoreHelper)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsautonomousui'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Autonomous UI
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [AutoSyncSceneToggle.cs](files/AutoSyncSceneToggle_cs.md) | 61 | 39 | 11 | [`C:AutoSyncSceneToggle`](files/AutoSyncSceneToggle_cs.md#AutoSyncSceneToggle)  |
| [BackgroundTimeOutField.cs](files/BackgroundTimeOutField_cs.md) | 68 | 48 | 11 | [`C:BackgroundTimeOutField`](files/BackgroundTimeOutField_cs.md#BackgroundTimeOutField)  |
| [CrcCheckToggle.cs](files/CrcCheckToggle_cs.md) | 61 | 39 | 11 | [`C:CrcCheckToggle`](files/CrcCheckToggle_cs.md#CrcCheckToggle)  |
| [DocLinkButton.cs](files/DocLinkButton_cs.md) | 33 | 16 | 11 | [`C:DocLinkButton`](files/DocLinkButton_cs.md#DocLinkButton)  |
| [GameVersionField.cs](files/GameVersionField_cs.md) | 68 | 48 | 11 | [`C:GameVersionField`](files/GameVersionField_cs.md#GameVersionField)  |
| [LayoutElementMatchSize.cs](files/LayoutElementMatchSize_cs.md) | 40 | 22 | 9 | [`C:LayoutElementMatchSize`](files/LayoutElementMatchSize_cs.md#LayoutElementMatchSize)  |
| [NickNameField.cs](files/NickNameField_cs.md) | 68 | 48 | 11 | [`C:NickNameField`](files/NickNameField_cs.md#NickNameField)  |
| [OnlineDocButton.cs](files/OnlineDocButton_cs.md) | 27 | 13 | 10 | [`C:OnlineDocButton`](files/OnlineDocButton_cs.md#OnlineDocButton)  |
| [SendRateField.cs](files/SendRateField_cs.md) | 70 | 48 | 11 | [`C:SendRateField`](files/SendRateField_cs.md#SendRateField)  |
| [SendRateOnSerializeField.cs](files/SendRateOnSerializeField_cs.md) | 69 | 48 | 11 | [`C:SendRateOnSerializeField`](files/SendRateOnSerializeField_cs.md#SendRateOnSerializeField)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsautonomousuicurrentroom'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Autonomous UI/CurrentRoom
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [CurrentRoomIsOpenToggle.cs](files/CurrentRoomIsOpenToggle_cs.md) | 66 | 43 | 10 | [`C:CurrentRoomIsOpenToggle`](files/CurrentRoomIsOpenToggle_cs.md#CurrentRoomIsOpenToggle)  |
| [CurrentRoomIsVisibleToggle.cs](files/CurrentRoomIsVisibleToggle_cs.md) | 65 | 43 | 10 | [`C:CurrentRoomIsVisibleToggle`](files/CurrentRoomIsVisibleToggle_cs.md#CurrentRoomIsVisibleToggle)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsautonomousuigeneric'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Autonomous UI/Generic
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [BoolInputField.cs](files/BoolInputField_cs.md) | 54 | 35 | 9 | [`C:BoolInputField`](files/BoolInputField_cs.md#BoolInputField)  |
| [IntInputField.cs](files/IntInputField_cs.md) | 67 | 48 | 9 | [`C:IntInputField`](files/IntInputField_cs.md#IntInputField)  |
| [StringInputField.cs](files/StringInputField_cs.md) | 65 | 46 | 9 | [`C:StringInputField`](files/StringInputField_cs.md#StringInputField)  |
| [ToggleExpand.cs](files/ToggleExpand_cs.md) | 45 | 25 | 9 | [`C:ToggleExpand`](files/ToggleExpand_cs.md#ToggleExpand)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptscontrollers'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Controllers
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PlayerDetailsController.cs](files/PlayerDetailsController_cs.md) | 239 | 162 | 14 | [`C:PlayerDetailsController`](files/PlayerDetailsController_cs.md#PlayerDetailsController)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptslists'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/Lists
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [FriendListCell.cs](files/FriendListCell_cs.md) | 63 | 37 | 10 | [`C:FriendListCell`](files/FriendListCell_cs.md#FriendListCell)  |
| [FriendListView.cs](files/FriendListView_cs.md) | 162 | 109 | 14 | [`C:FriendListView`](files/FriendListView_cs.md#FriendListView)  |
| [PlayerListCell.cs](files/PlayerListCell_cs.md) | 134 | 83 | 14 | [`C:PlayerListCell`](files/PlayerListCell_cs.md#PlayerListCell)  |
| [PlayerListView.cs](files/PlayerListView_cs.md) | 184 | 117 | 27 | [`C:PlayerListView`](files/PlayerListView_cs.md#PlayerListView)  |
| [PropertyCell.cs](files/PropertyCell_cs.md) | 101 | 71 | 9 | [`C:PropertyCell`](files/PropertyCell_cs.md#PropertyCell)  |
| [RegionListCell.cs](files/RegionListCell_cs.md) | 81 | 53 | 9 | [`C:RegionListCell`](files/RegionListCell_cs.md#RegionListCell)  |
| [RegionListView.cs](files/RegionListView_cs.md) | 64 | 39 | 10 | [`C:RegionListView`](files/RegionListView_cs.md#RegionListView)  |
| [RoomListCell.cs](files/RoomListCell_cs.md) | 102 | 75 | 9 | [`C:RoomListCell`](files/RoomListCell_cs.md#RoomListCell)  |
| [RoomListView.cs](files/RoomListView_cs.md) | 147 | 98 | 12 | [`C:RoomListView`](files/RoomListView_cs.md#RoomListView)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptspropertyfields'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/PropertyFields
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [UserIdField.cs](files/UserIdField_cs.md) | 71 | 49 | 11 | [`C:UserIdField`](files/UserIdField_cs.md#UserIdField)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsreadonlyproperties'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/ReadOnlyProperties
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [AppVersionProperty.cs](files/AppVersionProperty_cs.md) | 32 | 18 | 9 | [`C:AppVersionProperty`](files/AppVersionProperty_cs.md#AppVersionProperty)  |
| [BestRegionInPrefsProperty.cs](files/BestRegionInPrefsProperty_cs.md) | 40 | 25 | 9 | [`C:BestRegionInPrefsProperty`](files/BestRegionInPrefsProperty_cs.md#BestRegionInPrefsProperty)  |
| [CloudRegionProperty.cs](files/CloudRegionProperty_cs.md) | 38 | 25 | 9 | [`C:CloudRegionProperty`](files/CloudRegionProperty_cs.md#CloudRegionProperty)  |
| [CountOfPlayersInRoomProperty.cs](files/CountOfPlayersInRoomProperty_cs.md) | 44 | 30 | 9 | [`C:CountOfPlayersInRoomProperty`](files/CountOfPlayersInRoomProperty_cs.md#CountOfPlayersInRoomProperty)  |
| [CountOfPlayersOnMasterProperty.cs](files/CountOfPlayersOnMasterProperty_cs.md) | 44 | 30 | 9 | [`C:CountOfPlayersOnMasterProperty`](files/CountOfPlayersOnMasterProperty_cs.md#CountOfPlayersOnMasterProperty)  |
| [CountOfPlayersProperty.cs](files/CountOfPlayersProperty_cs.md) | 44 | 30 | 9 | [`C:CountOfPlayersProperty`](files/CountOfPlayersProperty_cs.md#CountOfPlayersProperty)  |
| [CountOfRoomsProperty.cs](files/CountOfRoomsProperty_cs.md) | 43 | 30 | 9 | [`C:CountOfRoomsProperty`](files/CountOfRoomsProperty_cs.md#CountOfRoomsProperty)  |
| [CurrentRoomAutoCleanupProperty.cs](files/CurrentRoomAutoCleanupProperty_cs.md) | 44 | 29 | 9 | [`C:CurrentRoomAutoCleanupProperty`](files/CurrentRoomAutoCleanupProperty_cs.md#CurrentRoomAutoCleanupProperty)  |
| [CurrentRoomEmptyRoomTtlProperty.cs](files/CurrentRoomEmptyRoomTtlProperty_cs.md) | 43 | 29 | 9 | [`C:CurrentRoomEmptyRoomTtlProperty`](files/CurrentRoomEmptyRoomTtlProperty_cs.md#CurrentRoomEmptyRoomTtlProperty)  |
| [CurrentRoomExpectedUsersProperty.cs](files/CurrentRoomExpectedUsersProperty_cs.md) | 58 | 34 | 9 | [`C:CurrentRoomExpectedUsersProperty`](files/CurrentRoomExpectedUsersProperty_cs.md#CurrentRoomExpectedUsersProperty)  |
| [CurrentRoomIsOfflineProperty.cs](files/CurrentRoomIsOfflineProperty_cs.md) | 44 | 29 | 9 | [`C:CurrentRoomIsOfflineProperty`](files/CurrentRoomIsOfflineProperty_cs.md#CurrentRoomIsOfflineProperty)  |
| [CurrentRoomIsOpenProperty.cs](files/CurrentRoomIsOpenProperty_cs.md) | 42 | 29 | 9 | [`C:CurrentRoomIsOpenProperty`](files/CurrentRoomIsOpenProperty_cs.md#CurrentRoomIsOpenProperty)  |
| [CurrentRoomIsVisibleProperty.cs](files/CurrentRoomIsVisibleProperty_cs.md) | 44 | 29 | 9 | [`C:CurrentRoomIsVisibleProperty`](files/CurrentRoomIsVisibleProperty_cs.md#CurrentRoomIsVisibleProperty)  |
| [CurrentRoomMasterClientIdProperty.cs](files/CurrentRoomMasterClientIdProperty_cs.md) | 42 | 29 | 9 | [`C:CurrentRoomMasterClientIdProperty`](files/CurrentRoomMasterClientIdProperty_cs.md#CurrentRoomMasterClientIdProperty)  |
| [CurrentRoomMaxPlayersProperty.cs](files/CurrentRoomMaxPlayersProperty_cs.md) | 42 | 29 | 9 | [`C:CurrentRoomMaxPlayersProperty`](files/CurrentRoomMaxPlayersProperty_cs.md#CurrentRoomMaxPlayersProperty)  |
| [CurrentRoomNameProperty.cs](files/CurrentRoomNameProperty_cs.md) | 43 | 29 | 9 | [`C:CurrentRoomNameProperty`](files/CurrentRoomNameProperty_cs.md#CurrentRoomNameProperty)  |
| [CurrentRoomPlayerCountProperty.cs](files/CurrentRoomPlayerCountProperty_cs.md) | 42 | 29 | 9 | [`C:CurrentRoomPlayerCountProperty`](files/CurrentRoomPlayerCountProperty_cs.md#CurrentRoomPlayerCountProperty)  |
| [CurrentRoomPlayerTtlProperty.cs](files/CurrentRoomPlayerTtlProperty_cs.md) | 43 | 29 | 9 | [`C:CurrentRoomPlayerTtlProperty`](files/CurrentRoomPlayerTtlProperty_cs.md#CurrentRoomPlayerTtlProperty)  |
| [CurrentRoomPropertiesListedInLobbyProperty.cs](files/CurrentRoomPropertiesListedInLobbyProperty_cs.md) | 47 | 30 | 9 | [`C:CurrentRoomPropertiesListedInLobbyProperty`](files/CurrentRoomPropertiesListedInLobbyProperty_cs.md#CurrentRoomPropertiesListedInLobbyProperty)  |
| [GameVersionProperty.cs](files/GameVersionProperty_cs.md) | 30 | 17 | 9 | [`C:GameVersionProperty`](files/GameVersionProperty_cs.md#GameVersionProperty)  |
| [IsConnectedAndReadyProperty.cs](files/IsConnectedAndReadyProperty_cs.md) | 33 | 18 | 9 | [`C:IsConnectedAndReadyProperty`](files/IsConnectedAndReadyProperty_cs.md#IsConnectedAndReadyProperty)  |
| [IsConnectedProperty.cs](files/IsConnectedProperty_cs.md) | 32 | 18 | 9 | [`C:IsConnectedProperty`](files/IsConnectedProperty_cs.md#IsConnectedProperty)  |
| [OfflineModeProperty.cs](files/OfflineModeProperty_cs.md) | 32 | 18 | 9 | [`C:OfflineModeProperty`](files/OfflineModeProperty_cs.md#OfflineModeProperty)  |
| [PingProperty.cs](files/PingProperty_cs.md) | 42 | 29 | 9 | [`C:PingProperty`](files/PingProperty_cs.md#PingProperty)  |
| [PropertyListenerBase.cs](files/PropertyListenerBase_cs.md) | 43 | 28 | 9 | [`C:PropertyListenerBase`](files/PropertyListenerBase_cs.md#PropertyListenerBase)  |
| [ServerAddressProperty.cs](files/ServerAddressProperty_cs.md) | 42 | 29 | 9 | [`C:ServerAddressProperty`](files/ServerAddressProperty_cs.md#ServerAddressProperty)  |
| [ServerProperty.cs](files/ServerProperty_cs.md) | 35 | 19 | 9 | [`C:ServerProperty`](files/ServerProperty_cs.md#ServerProperty)  |

<a id='folder-assetsphotonphotonunitynetworkingdemospuncockpitscriptsthirdparty'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/PunCockpit/Scripts/ThirdParty
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PunCockpitEmbed.cs](files/PunCockpitEmbed_cs.md) | 102 | 55 | 17 | [`C:PunCockpitEmbed`](files/PunCockpitEmbed_cs.md#PunCockpitEmbed)  |

<a id='folder-assetsphotonphotonunitynetworkingdemossharedassetsscripts'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/Demos/Shared Assets/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [DocLinks.cs](files/DocLinks_cs.md) | 158 | 63 | 72 | [`C:DocLinks`](files/DocLinks_cs.md#DocLinks)  |
| [ThirdPersonCharacter.cs](files/ThirdPersonCharacter_cs.md) | 226 | 172 | 23 | [`C:ThirdPersonCharacter`](files/ThirdPersonCharacter_cs.md#ThirdPersonCharacter)  |
| [ThirdPersonUserControl.cs](files/ThirdPersonUserControl_cs.md) | 75 | 54 | 10 | [`C:ThirdPersonUserControl`](files/ThirdPersonUserControl_cs.md#ThirdPersonUserControl)  |

<a id='folder-assetsphotonphotonunitynetworkingutilityscriptsculling'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/UtilityScripts/Culling
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [CullArea.cs](files/CullArea_cs.md) | 501 | 281 | 144 | [`C:CullArea`](files/CullArea_cs.md#CullArea)  |
| [CullingHandler.cs](files/CullingHandler_cs.md) | 254 | 159 | 47 | [`C:CullingHandler`](files/CullingHandler_cs.md#CullingHandler)  |

<a id='folder-assetsphotonphotonunitynetworkingutilityscriptsdebugging'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/UtilityScripts/Debugging
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PhotonLagSimulationGui.cs](files/PhotonLagSimulationGui_cs.md) | 109 | 67 | 21 | [`C:PhotonLagSimulationGui`](files/PhotonLagSimulationGui_cs.md#PhotonLagSimulationGui)  |
| [PhotonStatsGui.cs](files/PhotonStatsGui_cs.md) | 170 | 114 | 32 | [`C:PhotonStatsGui`](files/PhotonStatsGui_cs.md#PhotonStatsGui)  |
| [PointedAtGameObjectInfo.cs](files/PointedAtGameObjectInfo_cs.md) | 84 | 56 | 12 | [`C:PointedAtGameObjectInfo`](files/PointedAtGameObjectInfo_cs.md#PointedAtGameObjectInfo)  |
| [StatesGui.cs](files/StatesGui_cs.md) | 212 | 176 | 12 | [`C:StatesGui`](files/StatesGui_cs.md#StatesGui)  |

<a id='folder-assetsphotonphotonunitynetworkingutilityscriptsphotonplayer'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/UtilityScripts/PhotonPlayer
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PhotonTeamsManager.cs](files/PhotonTeamsManager_cs.md) | 628 | 440 | 129 | [`C:PhotonTeamsManager`](files/PhotonTeamsManager_cs.md#PhotonTeamsManager)  |
| [PlayerNumbering.cs](files/PlayerNumbering_cs.md) | 267 | 160 | 55 | [`C:PlayerNumbering`](files/PlayerNumbering_cs.md#PlayerNumbering)  |
| [PunPlayerScores.cs](files/PunPlayerScores_cs.md) | 62 | 39 | 12 | [`C:PunPlayerScores`](files/PunPlayerScores_cs.md#PunPlayerScores)  |
| [PunTeams.cs](files/PunTeams_cs.md) | 156 | 98 | 35 | [`C:PunTeams`](files/PunTeams_cs.md#PunTeams)  |

<a id='folder-assetsphotonphotonunitynetworkingutilityscriptsphotonview'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/UtilityScripts/PhotonView
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [SmoothSyncMovement.cs](files/SmoothSyncMovement_cs.md) | 72 | 50 | 15 | [`C:SmoothSyncMovement`](files/SmoothSyncMovement_cs.md#SmoothSyncMovement)  |

<a id='folder-assetsphotonphotonunitynetworkingutilityscriptsprototyping'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/UtilityScripts/Prototyping
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [ConnectAndJoinRandom.cs](files/ConnectAndJoinRandom_cs.md) | 137 | 53 | 53 | [`C:ConnectAndJoinRandom`](files/ConnectAndJoinRandom_cs.md#ConnectAndJoinRandom)  |
| [MoveByKeys.cs](files/MoveByKeys_cs.md) | 111 | 64 | 33 | [`C:MoveByKeys`](files/MoveByKeys_cs.md#MoveByKeys)  |
| [OnClickDestroy.cs](files/OnClickDestroy_cs.md) | 72 | 33 | 29 | [`C:OnClickDestroy`](files/OnClickDestroy_cs.md#OnClickDestroy)  |
| [OnClickInstantiate.cs](files/OnClickInstantiate_cs.md) | 56 | 30 | 14 | [`C:OnClickInstantiate`](files/OnClickInstantiate_cs.md#OnClickInstantiate)  |
| [OnClickRpc.cs](files/OnClickRpc_cs.md) | 89 | 57 | 12 | [`C:OnClickRpc`](files/OnClickRpc_cs.md#OnClickRpc)  |
| [OnEscapeQuit.cs](files/OnEscapeQuit_cs.md) | 32 | 17 | 13 | [`C:OnEscapeQuit`](files/OnEscapeQuit_cs.md#OnEscapeQuit)  |
| [OnJoinedInstantiate.cs](files/OnJoinedInstantiate_cs.md) | 451 | 300 | 58 | [`C:OnJoinedInstantiate`](files/OnJoinedInstantiate_cs.md#OnJoinedInstantiate)  |
| [OnStartDelete.cs](files/OnStartDelete_cs.md) | 24 | 11 | 11 | [`C:OnStartDelete`](files/OnStartDelete_cs.md#OnStartDelete)  |

<a id='folder-assetsphotonphotonunitynetworkingutilityscriptsroom'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/UtilityScripts/Room
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [CountdownTimer.cs](files/CountdownTimer_cs.md) | 176 | 101 | 33 | [`C:CountdownTimer`](files/CountdownTimer_cs.md#CountdownTimer)  |

<a id='folder-assetsphotonphotonunitynetworkingutilityscriptsturnbased'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/UtilityScripts/TurnBased
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [PunTurnManager.cs](files/PunTurnManager_cs.md) | 430 | 206 | 146 | [`C:PunTurnManager`](files/PunTurnManager_cs.md#PunTurnManager)  |

<a id='folder-assetsphotonphotonunitynetworkingutilityscriptsui'></a>
### Folder: Assets/Photon/PhotonUnityNetworking/UtilityScripts/UI
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [ButtonInsideScrollList.cs](files/ButtonInsideScrollList_cs.md) | 53 | 31 | 14 | [`C:ButtonInsideScrollList`](files/ButtonInsideScrollList_cs.md#ButtonInsideScrollList)  |
| [EventSystemSpawner.cs](files/EventSystemSpawner_cs.md) | 40 | 23 | 13 | [`C:EventSystemSpawner`](files/EventSystemSpawner_cs.md#EventSystemSpawner)  |
| [GraphicToggleIsOnTransition.cs](files/GraphicToggleIsOnTransition_cs.md) | 64 | 41 | 11 | [`C:GraphicToggleIsOnTransition`](files/GraphicToggleIsOnTransition_cs.md#GraphicToggleIsOnTransition)  |
| [OnPointerOverTooltip.cs](files/OnPointerOverTooltip_cs.md) | 45 | 24 | 10 | [`C:OnPointerOverTooltip`](files/OnPointerOverTooltip_cs.md#OnPointerOverTooltip)  |
| [TabViewManager.cs](files/TabViewManager_cs.md) | 123 | 65 | 33 | [`C:TabViewManager`](files/TabViewManager_cs.md#TabViewManager)  |
| [TextButtonTransition.cs](files/TextButtonTransition_cs.md) | 70 | 38 | 20 | [`C:TextButtonTransition`](files/TextButtonTransition_cs.md#TextButtonTransition)  |
| [TextToggleIsOnTransition.cs](files/TextToggleIsOnTransition_cs.md) | 86 | 41 | 26 | [`C:TextToggleIsOnTransition`](files/TextToggleIsOnTransition_cs.md#TextToggleIsOnTransition)  |

<a id='folder-assetspluginsdemigiantdotweenmodules'></a>
### Folder: Assets/Plugins/Demigiant/DOTween/Modules
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [DOTweenModuleAudio.cs](files/DOTweenModuleAudio_cs.md) | 199 | 94 | 80 | [`C:DOTweenModuleAudio`](files/DOTweenModuleAudio_cs.md#DOTweenModuleAudio)  |
| [DOTweenModuleEPOOutline.cs](files/DOTweenModuleEPOOutline_cs.md) | 147 | 109 | 18 |  |
| [DOTweenModulePhysics.cs](files/DOTweenModulePhysics_cs.md) | 217 | 137 | 60 | [`C:DOTweenModulePhysics`](files/DOTweenModulePhysics_cs.md#DOTweenModulePhysics)  |
| [DOTweenModulePhysics2D.cs](files/DOTweenModulePhysics2D_cs.md) | 194 | 125 | 51 | [`C:DOTweenModulePhysics2D`](files/DOTweenModulePhysics2D_cs.md#DOTweenModulePhysics2D)  |
| [DOTweenModuleSprite.cs](files/DOTweenModuleSprite_cs.md) | 94 | 63 | 17 | [`C:DOTweenModuleSprite`](files/DOTweenModuleSprite_cs.md#DOTweenModuleSprite)  |
| [DOTweenModuleUI.cs](files/DOTweenModuleUI_cs.md) | 663 | 390 | 203 | [`C:DOTweenModuleUI`](files/DOTweenModuleUI_cs.md#DOTweenModuleUI)  |
| [DOTweenModuleUnityVersion.cs](files/DOTweenModuleUnityVersion_cs.md) | 390 | 254 | 99 | [`C:DOTweenModuleUnityVersion`](files/DOTweenModuleUnityVersion_cs.md#DOTweenModuleUnityVersion)  |
| [DOTweenModuleUtils.cs](files/DOTweenModuleUtils_cs.md) | 168 | 123 | 27 | [`C:DOTweenModuleUtils`](files/DOTweenModuleUtils_cs.md#DOTweenModuleUtils)  |

<a id='folder-assetspluginsdemigiantdotweenpro'></a>
### Folder: Assets/Plugins/Demigiant/DOTweenPro
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [DOTweenAnimation.cs](files/DOTweenAnimation_cs.md) | 918 | 677 | 167 | [`C:DOTweenAnimation`](files/DOTweenAnimation_cs.md#DOTweenAnimation)  |
| [DOTweenDeAudio.cs](files/DOTweenDeAudio_cs.md) | 10 | 2 | 5 |  |
| [DOTweenDeUnityExtended.cs](files/DOTweenDeUnityExtended_cs.md) | 10 | 2 | 5 |  |
| [DOTweenProShortcuts.cs](files/DOTweenProShortcuts_cs.md) | 91 | 55 | 21 | [`C:DOTweenProShortcuts`](files/DOTweenProShortcuts_cs.md#DOTweenProShortcuts)  |
| [DOTweenTextMeshPro.cs](files/DOTweenTextMeshPro_cs.md) | 1038 | 674 | 279 |  |
| [DOTweenTk2d.cs](files/DOTweenTk2d_cs.md) | 248 | 160 | 70 |  |

<a id='folder-assetsscripts'></a>
### Folder: Assets/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [AspectRatioEnforcer.cs](files/AspectRatioEnforcer_cs.md) | 88 | 43 | 33 | [`C:AspectRatioEnforcer`](files/AspectRatioEnforcer_cs.md#AspectRatioEnforcer)  |
| [AttackedCard.cs](files/AttackedCard_cs.md) | 34 | 16 | 13 | [`C:AttackedCard`](files/AttackedCard_cs.md#AttackedCard)  |
| [AttackedLeader.cs](files/AttackedLeader_cs.md) | 25 | 12 | 10 | [`C:AttackedLeader`](files/AttackedLeader_cs.md#AttackedLeader)  |
| [BattleBgmManager.cs](files/BattleBgmManager_cs.md) | 45 | 25 | 14 | [`C:BattleBgmManager`](files/BattleBgmManager_cs.md#BattleBgmManager)  |
| [BattleCardMovement.cs](files/BattleCardMovement_cs.md) | 242 | 133 | 61 | [`C:BattleCardMovement`](files/BattleCardMovement_cs.md#BattleCardMovement)  |
| [BattleManager.cs](files/BattleManager_cs.md) | 1613 | 1025 | 325 | [`C:BattleManager`](files/BattleManager_cs.md#BattleManager)  |
| [BGMManager.cs](files/BGMManager_cs.md) | 56 | 32 | 17 | [`C:BGMManager`](files/BGMManager_cs.md#BGMManager)  |
| [CardController.cs](files/CardController_cs.md) | 1478 | 1142 | 127 | [`C:CardController`](files/CardController_cs.md#CardController)  |
| [CardDetailPanel.cs](files/CardDetailPanel_cs.md) | 38 | 22 | 11 | [`C:CardDetailPanel`](files/CardDetailPanel_cs.md#CardDetailPanel)  |
| [CardEntity.cs](files/CardEntity_cs.md) | 84 | 69 | 7 | [`C:CardEntity`](files/CardEntity_cs.md#CardEntity)  |
| [CardModel.cs](files/CardModel_cs.md) | 246 | 105 | 70 | [`C:CardModel`](files/CardModel_cs.md#CardModel)  |
| [CardMovement.cs](files/CardMovement_cs.md) | 102 | 56 | 29 | [`C:CardMovement`](files/CardMovement_cs.md#CardMovement)  |
| [CardView.cs](files/CardView_cs.md) | 123 | 81 | 28 | [`C:CardView`](files/CardView_cs.md#CardView)  |
| [DeckEditManager.cs](files/DeckEditManager_cs.md) | 450 | 306 | 84 | [`C:DeckEditManager`](files/DeckEditManager_cs.md#DeckEditManager)  |
| [DeckListManager.cs](files/DeckListManager_cs.md) | 64 | 35 | 13 | [`C:DeckListManager`](files/DeckListManager_cs.md#DeckListManager)  |
| [DeckSelectManager.cs](files/DeckSelectManager_cs.md) | 90 | 60 | 14 | [`C:DeckSelectManager`](files/DeckSelectManager_cs.md#DeckSelectManager)  |
| [DropDeckCardPlace.cs](files/DropDeckCardPlace_cs.md) | 51 | 39 | 7 | [`C:DropDeckCardPlace`](files/DropDeckCardPlace_cs.md#DropDeckCardPlace)  |
| [DropMulliganPlace.cs](files/DropMulliganPlace_cs.md) | 27 | 19 | 5 | [`C:DropMulliganPlace`](files/DropMulliganPlace_cs.md#DropMulliganPlace)  |
| [DropPlace.cs](files/DropPlace_cs.md) | 28 | 19 | 6 | [`C:DropPlace`](files/DropPlace_cs.md#DropPlace)  |
| [DropStockCardPlace.cs](files/DropStockCardPlace_cs.md) | 42 | 27 | 7 | [`C:DropStockCardPlace`](files/DropStockCardPlace_cs.md#DropStockCardPlace)  |
| [GameManager.cs](files/GameManager_cs.md) | 74 | 42 | 18 | [`C:GameManager`](files/GameManager_cs.md#GameManager)  |
| [HomeManager.cs](files/HomeManager_cs.md) | 45 | 36 | 4 | [`C:HomeManager`](files/HomeManager_cs.md#HomeManager)  |
| [MenuCardSpawner.cs](files/MenuCardSpawner_cs.md) | 157 | 104 | 28 | [`C:MenuCardSpawner`](files/MenuCardSpawner_cs.md#MenuCardSpawner)  |
| [OnlineMenuManager.cs](files/OnlineMenuManager_cs.md) | 101 | 56 | 33 | [`C:OnlineMenuManager`](files/OnlineMenuManager_cs.md#OnlineMenuManager)  |
| [OpenPackManager.cs](files/OpenPackManager_cs.md) | 168 | 124 | 21 | [`C:OpenPackManager`](files/OpenPackManager_cs.md#OpenPackManager)  |
| [PackController.cs](files/PackController_cs.md) | 36 | 21 | 9 | [`C:PackController`](files/PackController_cs.md#PackController)  |
| [PackEntity.cs](files/PackEntity_cs.md) | 19 | 13 | 3 | [`C:PackEntity`](files/PackEntity_cs.md#PackEntity)  |
| [PackView.cs](files/PackView_cs.md) | 18 | 13 | 3 | [`C:PackView`](files/PackView_cs.md#PackView)  |
| [PurchasePackPanel.cs](files/PurchasePackPanel_cs.md) | 62 | 40 | 11 | [`C:PurchasePackPanel`](files/PurchasePackPanel_cs.md#PurchasePackPanel)  |
| [RotatePanel.cs](files/RotatePanel_cs.md) | 20 | 11 | 5 | [`C:RotatePanel`](files/RotatePanel_cs.md#RotatePanel)  |
| [ScalePanel.cs](files/ScalePanel_cs.md) | 37 | 20 | 9 | [`C:ScalePanel`](files/ScalePanel_cs.md#ScalePanel)  |
| [SceneFadeManager.cs](files/SceneFadeManager_cs.md) | 96 | 62 | 19 | [`C:SceneFadeManager`](files/SceneFadeManager_cs.md#SceneFadeManager)  |
| [SceneTransitionHandler.cs](files/SceneTransitionHandler_cs.md) | 47 | 33 | 8 | [`C:SceneTransitionHandler`](files/SceneTransitionHandler_cs.md#SceneTransitionHandler)  |
| [SceneTransitionManager.cs](files/SceneTransitionManager_cs.md) | 35 | 24 | 7 | [`C:SceneTransitionManager`](files/SceneTransitionManager_cs.md#SceneTransitionManager)  |
| [SelectPackButtonManager.cs](files/SelectPackButtonManager_cs.md) | 32 | 23 | 4 | [`C:SelectPackButtonManager`](files/SelectPackButtonManager_cs.md#SelectPackButtonManager)  |
| [ShopManager.cs](files/ShopManager_cs.md) | 49 | 35 | 7 | [`C:ShopManager`](files/ShopManager_cs.md#ShopManager)  |
| [SoundManager.cs](files/SoundManager_cs.md) | 43 | 25 | 11 | [`C:SoundManager`](files/SoundManager_cs.md#SoundManager)  |
| [StartManager.cs](files/StartManager_cs.md) | 30 | 16 | 6 | [`C:StartManager`](files/StartManager_cs.md#StartManager)  |
| [TouchClose.cs](files/TouchClose_cs.md) | 20 | 12 | 6 | [`C:TouchClose`](files/TouchClose_cs.md#TouchClose)  |
| [UIManager.cs](files/UIManager_cs.md) | 445 | 307 | 87 | [`C:UIManager`](files/UIManager_cs.md#UIManager)  |
| [VolumeSlider.cs](files/VolumeSlider_cs.md) | 31 | 18 | 8 | [`C:VolumeSlider`](files/VolumeSlider_cs.md#VolumeSlider)  |

<a id='folder-assetstextmeshproexamplesextrasscripts'></a>
### Folder: Assets/TextMesh Pro/Examples & Extras/Scripts
| ファイル名 | 行数 | コード | コメント | 定義クラス |
| :--- | :---: | :---: | :---: | :--- |
| [Benchmark01.cs](files/Benchmark01_cs.md) | 129 | 75 | 16 | [`C:Benchmark01`](files/Benchmark01_cs.md#Benchmark01)  |
| [Benchmark01_UGUI.cs](files/Benchmark01_UGUI_cs.md) | 136 | 71 | 24 | [`C:Benchmark01_UGUI`](files/Benchmark01_UGUI_cs.md#Benchmark01_UGUI)  |
| [Benchmark02.cs](files/Benchmark02_cs.md) | 98 | 65 | 6 | [`C:Benchmark02`](files/Benchmark02_cs.md#Benchmark02)  |
| [Benchmark03.cs](files/Benchmark03_cs.md) | 93 | 73 | 1 | [`C:Benchmark03`](files/Benchmark03_cs.md#Benchmark03)  |
| [Benchmark04.cs](files/Benchmark04_cs.md) | 86 | 51 | 11 | [`C:Benchmark04`](files/Benchmark04_cs.md#Benchmark04)  |
| [CameraController.cs](files/CameraController_cs.md) | 292 | 198 | 25 | [`C:CameraController`](files/CameraController_cs.md#CameraController)  |
| [ChatController.cs](files/ChatController_cs.md) | 52 | 31 | 5 | [`C:ChatController`](files/ChatController_cs.md#ChatController)  |
| [DropdownSample.cs](files/DropdownSample_cs.md) | 20 | 15 | 0 | [`C:DropdownSample`](files/DropdownSample_cs.md#DropdownSample)  |
| [EnvMapAnimator.cs](files/EnvMapAnimator_cs.md) | 36 | 23 | 4 | [`C:EnvMapAnimator`](files/EnvMapAnimator_cs.md#EnvMapAnimator)  |
| [ObjectSpin.cs](files/ObjectSpin_cs.md) | 69 | 50 | 4 | [`C:ObjectSpin`](files/ObjectSpin_cs.md#ObjectSpin)  |
| [ShaderPropAnimator.cs](files/ShaderPropAnimator_cs.md) | 52 | 33 | 5 | [`C:ShaderPropAnimator`](files/ShaderPropAnimator_cs.md#ShaderPropAnimator)  |
| [SimpleScript.cs](files/SimpleScript_cs.md) | 59 | 24 | 15 | [`C:SimpleScript`](files/SimpleScript_cs.md#SimpleScript)  |
| [SkewTextExample.cs](files/SkewTextExample_cs.md) | 159 | 95 | 18 | [`C:SkewTextExample`](files/SkewTextExample_cs.md#SkewTextExample)  |
| [TeleType.cs](files/TeleType_cs.md) | 83 | 40 | 15 | [`C:TeleType`](files/TeleType_cs.md#TeleType)  |
| [TextConsoleSimulator.cs](files/TextConsoleSimulator_cs.md) | 121 | 79 | 13 | [`C:TextConsoleSimulator`](files/TextConsoleSimulator_cs.md#TextConsoleSimulator)  |
| [TextMeshProFloatingText.cs](files/TextMeshProFloatingText_cs.md) | 224 | 135 | 32 | [`C:TextMeshProFloatingText`](files/TextMeshProFloatingText_cs.md#TextMeshProFloatingText)  |
| [TextMeshSpawner.cs](files/TextMeshSpawner_cs.md) | 80 | 46 | 13 | [`C:TextMeshSpawner`](files/TextMeshSpawner_cs.md#TextMeshSpawner)  |
| [TMP_DigitValidator.cs](files/TMP_DigitValidator_cs.md) | 28 | 19 | 5 | [`C:TMP_DigitValidator`](files/TMP_DigitValidator_cs.md#TMP_DigitValidator)  |
| [TMP_ExampleScript_01.cs](files/TMP_ExampleScript_01_cs.md) | 65 | 37 | 9 | [`C:TMP_ExampleScript_01`](files/TMP_ExampleScript_01_cs.md#TMP_ExampleScript_01)  |
| [TMP_FrameRateCounter.cs](files/TMP_FrameRateCounter_cs.md) | 135 | 91 | 11 | [`C:TMP_FrameRateCounter`](files/TMP_FrameRateCounter_cs.md#TMP_FrameRateCounter)  |
| [TMP_PhoneNumberValidator.cs](files/TMP_PhoneNumberValidator_cs.md) | 106 | 93 | 7 | [`C:TMP_PhoneNumberValidator`](files/TMP_PhoneNumberValidator_cs.md#TMP_PhoneNumberValidator)  |
| [TMP_TextEventCheck.cs](files/TMP_TextEventCheck_cs.md) | 74 | 56 | 1 | [`C:TMP_TextEventCheck`](files/TMP_TextEventCheck_cs.md#TMP_TextEventCheck)  |
| [TMP_TextEventHandler.cs](files/TMP_TextEventHandler_cs.md) | 255 | 170 | 31 | [`C:TMP_TextEventHandler`](files/TMP_TextEventHandler_cs.md#TMP_TextEventHandler)  |
| [TMP_TextInfoDebugTool.cs](files/TMP_TextInfoDebugTool_cs.md) | 653 | 409 | 97 | [`C:TMP_TextInfoDebugTool`](files/TMP_TextInfoDebugTool_cs.md#TMP_TextInfoDebugTool)  |
| [TMP_TextSelector_A.cs](files/TMP_TextSelector_A_cs.md) | 158 | 100 | 17 | [`C:TMP_TextSelector_A`](files/TMP_TextSelector_A_cs.md#TMP_TextSelector_A)  |
| [TMP_TextSelector_B.cs](files/TMP_TextSelector_B_cs.md) | 548 | 330 | 83 | [`C:TMP_TextSelector_B`](files/TMP_TextSelector_B_cs.md#TMP_TextSelector_B)  |
| [TMP_UiFrameRateCounter.cs](files/TMP_UiFrameRateCounter_cs.md) | 125 | 96 | 1 | [`C:TMP_UiFrameRateCounter`](files/TMP_UiFrameRateCounter_cs.md#TMP_UiFrameRateCounter)  |
| [TMPro_InstructionOverlay.cs](files/TMPro_InstructionOverlay_cs.md) | 85 | 55 | 6 | [`C:TMPro_InstructionOverlay`](files/TMPro_InstructionOverlay_cs.md#TMPro_InstructionOverlay)  |
| [VertexColorCycler.cs](files/VertexColorCycler_cs.md) | 85 | 48 | 13 | [`C:VertexColorCycler`](files/VertexColorCycler_cs.md#VertexColorCycler)  |
| [VertexJitter.cs](files/VertexJitter_cs.md) | 175 | 105 | 26 | [`C:VertexJitter`](files/VertexJitter_cs.md#VertexJitter)  |
| [VertexShakeA.cs](files/VertexShakeA_cs.md) | 161 | 99 | 23 | [`C:VertexShakeA`](files/VertexShakeA_cs.md#VertexShakeA)  |
| [VertexShakeB.cs](files/VertexShakeB_cs.md) | 185 | 112 | 29 | [`C:VertexShakeB`](files/VertexShakeB_cs.md#VertexShakeB)  |
| [VertexZoom.cs](files/VertexZoom_cs.md) | 192 | 112 | 32 | [`C:VertexZoom`](files/VertexZoom_cs.md#VertexZoom)  |
| [WarpTextExample.cs](files/WarpTextExample_cs.md) | 145 | 87 | 15 | [`C:WarpTextExample`](files/WarpTextExample_cs.md#WarpTextExample)  |

## クラス索引
| クラス名 | ファイル | 種類 | 名前空間 | 説明 |
| :--- | :--- | :---: | :--- | :--- |
| [AspectRatioEnforcer](files/AspectRatioEnforcer_cs.md#AspectRatioEnforcer) | [AspectRatioEnforcer.cs](files/AspectRatioEnforcer_cs.md) | Class | (Global) | 画面のアスペクト比を強制的に固定するクラス。 |
| [AttackedCard](files/AttackedCard_cs.md#AttackedCard) | [AttackedCard.cs](files/AttackedCard_cs.md) | Class | (Global) | カードにアタッチし、攻撃ドロップを受け付けるクラス, |
| [AttackedLeader](files/AttackedLeader_cs.md#AttackedLeader) | [AttackedLeader.cs](files/AttackedLeader_cs.md) | Class | (Global) | リーダーオブジェクトにアタッチし、リーダーへの攻撃ドロップを受け付けるクラス |
| [BattleBgmManager](files/BattleBgmManager_cs.md#BattleBgmManager) | [BattleBgmManager.cs](files/BattleBgmManager_cs.md) | Class | (Global) | バトルシーン専用のBGM管理クラス。 |
| [BattleCardMovement](files/BattleCardMovement_cs.md#BattleCardMovement) | [BattleCardMovement.cs](files/BattleCardMovement_cs.md) | Class | (Global) | バトルシーンにおけるカードの移動制御（ドラッグ＆ドロップ、攻撃モーション）を行うクラス |
| [BattleManager](files/BattleManager_cs.md#BattleManager) | [BattleManager.cs](files/BattleManager_cs.md) | Class | (Global) | バトルシーン全体の進行管理、ルール処理、通信同期を行うクラス |
| [BGMManager](files/BGMManager_cs.md#BGMManager) | [BGMManager.cs](files/BGMManager_cs.md) | Class | (Global) | メニュー画面などのBGM再生を管理するクラス。 |
| [CameraController](files/CameraController_cs.md#CameraController) | [CameraController.cs](files/CameraController_cs.md) | Class | (Global) |  |
| [CardController](files/CardController_cs.md#CardController) | [CardController.cs](files/CardController_cs.md) | Class | (Global) |  |
| [CardDetailPanel](files/CardDetailPanel_cs.md#CardDetailPanel) | [CardDetailPanel.cs](files/CardDetailPanel_cs.md) | Class | (Global) | カードをクリックした際に表示される詳細画面（ポップアップ）を制御するクラス。 |
| [CardEntity](files/CardEntity_cs.md#CardEntity) | [CardEntity.cs](files/CardEntity_cs.md) | Class | (Global) | カードのマスターデータを定義するScriptableObject。 |
| [CardModel](files/CardModel_cs.md#CardModel) | [CardModel.cs](files/CardModel_cs.md) | Class | (Global) | カードのデータを保持するクラス。 |
| [CardMovement](files/CardMovement_cs.md#CardMovement) | [CardMovement.cs](files/CardMovement_cs.md) | Class | (Global) | デッキ編集画面などにおける、カードの一般的な移動制御クラス。 |
| [CardView](files/CardView_cs.md#CardView) | [CardView.cs](files/CardView_cs.md) | Class | (Global) | カードの見た目（View）を制御するクラス。 |
| [ChatController](files/ChatController_cs.md#ChatController) | [ChatController.cs](files/ChatController_cs.md) | Class | (Global) |  |
| [DeckEditManager](files/DeckEditManager_cs.md#DeckEditManager) | [DeckEditManager.cs](files/DeckEditManager_cs.md) | Class | (Global) | デッキ編成画面（Deck Scene）の管理クラス。 |
| [DeckListManager](files/DeckListManager_cs.md#DeckListManager) | [DeckListManager.cs](files/DeckListManager_cs.md) | Class | (Global) | プレイヤーが作成した複数のデッキデータを保持・管理するクラス。 |
| [DeckSelectManager](files/DeckSelectManager_cs.md#DeckSelectManager) | [DeckSelectManager.cs](files/DeckSelectManager_cs.md) | Class | (Global) | 対戦前に使用するデッキを選択する画面の管理クラス。 |
| [DropDeckCardPlace](files/DropDeckCardPlace_cs.md#DropDeckCardPlace) | [DropDeckCardPlace.cs](files/DropDeckCardPlace_cs.md) | Class | (Global) | デッキ編成画面で「デッキエリア」にカードがドロップされた時の処理 |
| [DropdownSample](files/DropdownSample_cs.md#DropdownSample) | [DropdownSample.cs](files/DropdownSample_cs.md) | Class | (Global) |  |
| [DropMulliganPlace](files/DropMulliganPlace_cs.md#DropMulliganPlace) | [DropMulliganPlace.cs](files/DropMulliganPlace_cs.md) | Class | (Global) | バトル開始時のマリガン画面で、カード交換用エリアへのドロップを受け付けるクラス |
| [DropPlace](files/DropPlace_cs.md#DropPlace) | [DropPlace.cs](files/DropPlace_cs.md) | Class | (Global) | バトルフィールド（プレイエリア）へのドロップを受け付けるクラス。 |
| [DropStockCardPlace](files/DropStockCardPlace_cs.md#DropStockCardPlace) | [DropStockCardPlace.cs](files/DropStockCardPlace_cs.md) | Class | (Global) | デッキ編成画面で「所持カード（ストック）エリア」にカードがドロップされた時の処理。 |
| [EnvMapAnimator](files/EnvMapAnimator_cs.md#EnvMapAnimator) | [EnvMapAnimator.cs](files/EnvMapAnimator_cs.md) | Class | (Global) |  |
| [GameManager](files/GameManager_cs.md#GameManager) | [GameManager.cs](files/GameManager_cs.md) | Class | (Global) | ゲーム全体を通して存在するシングルトンマネージャー。 |
| [HomeManager](files/HomeManager_cs.md#HomeManager) | [HomeManager.cs](files/HomeManager_cs.md) | Class | (Global) | ホーム画面のボタン操作とシーン遷移を管理するクラス |
| [MenuCardSpawner](files/MenuCardSpawner_cs.md#MenuCardSpawner) | [MenuCardSpawner.cs](files/MenuCardSpawner_cs.md) | Class | (Global) | ホーム画面の背景演出として、カードをランダムに生成して落下させるクラス。 |
| [OnlineMenuManager](files/OnlineMenuManager_cs.md#OnlineMenuManager) | [OnlineMenuManager.cs](files/OnlineMenuManager_cs.md) | Class | (Global) | オンラインマッチング画面の制御クラス。 |
| [OpenPackManager](files/OpenPackManager_cs.md#OpenPackManager) | [OpenPackManager.cs](files/OpenPackManager_cs.md) | Class | (Global) | 不使用 |
| [PackController](files/PackController_cs.md#PackController) | [PackController.cs](files/PackController_cs.md) | Class | (Global) | 不使用 |
| [PackEntity](files/PackEntity_cs.md#PackEntity) | [PackEntity.cs](files/PackEntity_cs.md) | Class | (Global) | 不使用 |
| [PackView](files/PackView_cs.md#PackView) | [PackView.cs](files/PackView_cs.md) | Class | (Global) | 不使用 |
| [PurchasePackPanel](files/PurchasePackPanel_cs.md#PurchasePackPanel) | [PurchasePackPanel.cs](files/PurchasePackPanel_cs.md) | Class | (Global) | 不使用 |
| [RotatePanel](files/RotatePanel_cs.md#RotatePanel) | [RotatePanel.cs](files/RotatePanel_cs.md) | Class | (Global) | アタッチされたオブジェクトを一定速度で回転させる演出用スクリプト。 |
| [ScalePanel](files/ScalePanel_cs.md#ScalePanel) | [ScalePanel.cs](files/ScalePanel_cs.md) | Class | (Global) | アタッチされたオブジェクトを拡大・縮小（パルス）させる演出用スクリプト。 |
| [SceneFadeManager](files/SceneFadeManager_cs.md#SceneFadeManager) | [SceneFadeManager.cs](files/SceneFadeManager_cs.md) | Class | (Global) | シーン遷移時のフェードイン・フェードアウト演出を管理するクラス。 |
| [SceneTransitionHandler](files/SceneTransitionHandler_cs.md#SceneTransitionHandler) | [SceneTransitionHandler.cs](files/SceneTransitionHandler_cs.md) | Class | (Global) | シーンのロード完了イベントを監視し、シーンに応じた処理（BGM切り替え等）を行うクラス。 |
| [SceneTransitionManager](files/SceneTransitionManager_cs.md#SceneTransitionManager) | [SceneTransitionManager.cs](files/SceneTransitionManager_cs.md) | Class | (Global) | シーン遷移を一元管理するクラス。 |
| [SelectPackButtonManager](files/SelectPackButtonManager_cs.md#SelectPackButtonManager) | [SelectPackButtonManager.cs](files/SelectPackButtonManager_cs.md) | Class | (Global) | 不使用 |
| [ShopManager](files/ShopManager_cs.md#ShopManager) | [ShopManager.cs](files/ShopManager_cs.md) | Class | (Global) | 不使用 |
| [Slide](files/Slide_cs.md#Slide) | [Slide.cs](files/Slide_cs.md) | Class | (Global) |  |
| [SoundManager](files/SoundManager_cs.md#SoundManager) | [SoundManager.cs](files/SoundManager_cs.md) | Class | (Global) | ゲーム内のSE（効果音）再生を一元管理するクラス。 |
| [StartManager](files/StartManager_cs.md#StartManager) | [StartManager.cs](files/StartManager_cs.md) | Class | (Global) | タイトル画面（Start Scene）の制御クラス |
| [Togglescript](files/Togglescript_cs.md#Togglescript) | [Togglescript.cs](files/Togglescript_cs.md) | Class | (Global) |  |
| [TouchClose](files/TouchClose_cs.md#TouchClose) | [TouchClose.cs](files/TouchClose_cs.md) | Class | (Global) | クリック（タップ）された時に、開いている詳細パネルを閉じるクラス。 |
| [UIManager](files/UIManager_cs.md#UIManager) | [UIManager.cs](files/UIManager_cs.md) | Class | (Global) | ゲーム内のUI（ユーザーインターフェース）を一元管理するクラス。 |
| [VolumeSlider](files/VolumeSlider_cs.md#VolumeSlider) | [VolumeSlider.cs](files/VolumeSlider_cs.md) | Class | (Global) | UIのスライダー操作を受け取り、各サウンドマネージャーに音量変更を伝えるクラス。 |
| [DOTweenAnimation](files/DOTweenAnimation_cs.md#DOTweenAnimation) | [DOTweenAnimation.cs](files/DOTweenAnimation_cs.md) | Class | DG.Tweening | Attach this to a GameObject to create a tween |
| [DOTweenModuleAudio](files/DOTweenModuleAudio_cs.md#DOTweenModuleAudio) | [DOTweenModuleAudio.cs](files/DOTweenModuleAudio_cs.md) | Class | DG.Tweening |  |
| [DOTweenModulePhysics](files/DOTweenModulePhysics_cs.md#DOTweenModulePhysics) | [DOTweenModulePhysics.cs](files/DOTweenModulePhysics_cs.md) | Class | DG.Tweening |  |
| [DOTweenModulePhysics2D](files/DOTweenModulePhysics2D_cs.md#DOTweenModulePhysics2D) | [DOTweenModulePhysics2D.cs](files/DOTweenModulePhysics2D_cs.md) | Class | DG.Tweening |  |
| [DOTweenModuleSprite](files/DOTweenModuleSprite_cs.md#DOTweenModuleSprite) | [DOTweenModuleSprite.cs](files/DOTweenModuleSprite_cs.md) | Class | DG.Tweening |  |
| [DOTweenModuleUI](files/DOTweenModuleUI_cs.md#DOTweenModuleUI) | [DOTweenModuleUI.cs](files/DOTweenModuleUI_cs.md) | Class | DG.Tweening |  |
| [DOTweenModuleUnityVersion](files/DOTweenModuleUnityVersion_cs.md#DOTweenModuleUnityVersion) | [DOTweenModuleUnityVersion.cs](files/DOTweenModuleUnityVersion_cs.md) | Class | DG.Tweening | Shortcuts/functions that are not strictly related to specific Modules |
| [DOTweenModuleUtils](files/DOTweenModuleUtils_cs.md#DOTweenModuleUtils) | [DOTweenModuleUtils.cs](files/DOTweenModuleUtils_cs.md) | Class | DG.Tweening | Utility functions that deal with available Modules. |
| [DOTweenProShortcuts](files/DOTweenProShortcuts_cs.md#DOTweenProShortcuts) | [DOTweenProShortcuts.cs](files/DOTweenProShortcuts_cs.md) | Class | DG.Tweening |  |
| [ChannelCreationOptions](files/ChannelCreationOptions_cs.md#ChannelCreationOptions) | [ChannelCreationOptions.cs](files/ChannelCreationOptions_cs.md) | Class | Photon.Chat |  |
| [ChannelWellKnownProperties](files/ChannelWellKnownProperties_cs.md#ChannelWellKnownProperties) | [ChannelWellKnownProperties.cs](files/ChannelWellKnownProperties_cs.md) | Class | Photon.Chat |  |
| [ChatAppSettings](files/ChatAppSettings_cs.md#ChatAppSettings) | [ChatAppSettings.cs](files/ChatAppSettings_cs.md) | Class | Photon.Chat | Settings for Photon application(s) and the server to connect to. |
| [ChatChannel](files/ChatChannel_cs.md#ChatChannel) | [ChatChannel.cs](files/ChatChannel_cs.md) | Class | Photon.Chat | A channel of communication in Photon Chat, updated by ChatClient and provided as READ ONLY. |
| [ChatClient](files/ChatClient_cs.md#ChatClient) | [ChatClient.cs](files/ChatClient_cs.md) | Class | Photon.Chat | Central class of the Photon Chat API to connect, handle channels and messages. |
| [ChatEventCode](files/ChatEventCode_cs.md#ChatEventCode) | [ChatEventCode.cs](files/ChatEventCode_cs.md) | Class | Photon.Chat | Wraps up internally used constants in Photon Chat events. You don't have to use them directly usually. |
| [ChatOperationCode](files/ChatOperationCode_cs.md#ChatOperationCode) | [ChatOperationCode.cs](files/ChatOperationCode_cs.md) | Class | Photon.Chat | Wraps up codes for operations used internally in Photon Chat. You don't have to use them directly usually. |
| [ChatParameterCode](files/ChatParameterCode_cs.md#ChatParameterCode) | [ChatParameterCode.cs](files/ChatParameterCode_cs.md) | Class | Photon.Chat | Wraps up codes for parameters (in operations and events) used internally in Photon Chat. You don't have to use them directly usually. |
| [ChatPeer](files/ChatPeer_cs.md#ChatPeer) | [ChatPeer.cs](files/ChatPeer_cs.md) | Class | Photon.Chat | Provides basic operations of the Photon Chat server. This internal class is used by public ChatClient. |
| [ChatUserStatus](files/ChatUserStatus_cs.md#ChatUserStatus) | [ChatUserStatus.cs](files/ChatUserStatus_cs.md) | Class | Photon.Chat | Contains commonly used status values for SetOnlineStatus. You can define your own. |
| [AppSettingsExtensions](files/AppSettingsExtensions_cs.md#AppSettingsExtensions) | [AppSettingsExtensions.cs](files/AppSettingsExtensions_cs.md) | Class | Photon.Chat.Demo |  |
| [ChannelSelector](files/ChannelSelector_cs.md#ChannelSelector) | [ChannelSelector.cs](files/ChannelSelector_cs.md) | Class | Photon.Chat.Demo |  |
| [ChatAppIdCheckerUI](files/ChatAppIdCheckerUI_cs.md#ChatAppIdCheckerUI) | [ChatAppIdCheckerUI.cs](files/ChatAppIdCheckerUI_cs.md) | Class | Photon.Chat.Demo | This is used in the Editor Splash to properly inform the developer about the chat AppId requirement. |
| [ChatGui](files/ChatGui_cs.md#ChatGui) | [ChatGui.cs](files/ChatGui_cs.md) | Class | Photon.Chat.Demo | This simple Chat UI demonstrate basics usages of the Chat Api |
| [FriendItem](files/FriendItem_cs.md#FriendItem) | [FriendItem.cs](files/FriendItem_cs.md) | Class | Photon.Chat.Demo | Friend UI item used to represent the friend status as well as message. |
| [IgnoreUiRaycastWhenInactive](files/IgnoreUiRaycastWhenInactive_cs.md#IgnoreUiRaycastWhenInactive) | [IgnoreUiRaycastWhenInactive.cs](files/IgnoreUiRaycastWhenInactive_cs.md) | Class | Photon.Chat.Demo |  |
| [NamePickGui](files/NamePickGui_cs.md#NamePickGui) | [NamePickGui.cs](files/NamePickGui_cs.md) | Class | Photon.Chat.Demo |  |
| [EventSystemSpawner](files/EventSystemSpawner_cs.md#EventSystemSpawner) | [EventSystemSpawner.cs](files/EventSystemSpawner_cs.md) | Class | Photon.Chat.UtilityScripts | Event system spawner. Will add an EventSystem GameObject with an EventSystem component and a StandaloneInputModule component. |
| [OnStartDelete](files/OnStartDelete_cs.md#OnStartDelete) | [OnStartDelete.cs](files/OnStartDelete_cs.md) | Class | Photon.Chat.UtilityScripts | This component will destroy the GameObject it is attached to (in Start()). |
| [TextButtonTransition](files/TextButtonTransition_cs.md#TextButtonTransition) | [TextButtonTransition.cs](files/TextButtonTransition_cs.md) | Class | Photon.Chat.UtilityScripts | Use this on Button texts to have some color transition on the text as well without corrupting button's behaviour. |
| [TextToggleIsOnTransition](files/TextToggleIsOnTransition_cs.md#TextToggleIsOnTransition) | [TextToggleIsOnTransition.cs](files/TextToggleIsOnTransition_cs.md) | Class | Photon.Chat.UtilityScripts | Use this on toggles texts to have some color transition on the text depending on the isOn State. |
| [CustomTypes](files/CustomTypes_cs.md#CustomTypes) | [CustomTypes.cs](files/CustomTypes_cs.md) | Class | Photon.Pun | Internally used class, containing de/serialization method for PUN specific classes. |
| [NestedComponentUtilities](files/NestedComponentUtilities_cs.md#NestedComponentUtilities) | [NestedComponentUtilities.cs](files/NestedComponentUtilities_cs.md) | Class | Photon.Pun |  |
| [PhotonAnimatorView](files/PhotonAnimatorView_cs.md#PhotonAnimatorView) | [PhotonAnimatorView.cs](files/PhotonAnimatorView_cs.md) | Class | Photon.Pun | This class helps you to synchronize Mecanim animations |
| [PhotonHandler](files/PhotonHandler_cs.md#PhotonHandler) | [PhotonHandler.cs](files/PhotonHandler_cs.md) | Class | Photon.Pun | Internal MonoBehaviour that allows Photon to run an Update loop. |
| [PhotonNetwork](files/PhotonNetwork_cs.md#PhotonNetwork) | [PhotonNetwork.cs](files/PhotonNetwork_cs.md) | Class | Photon.Pun | The main class to use the PhotonNetwork plugin. |
| [PhotonRigidbody2DView](files/PhotonRigidbody2DView_cs.md#PhotonRigidbody2DView) | [PhotonRigidbody2DView.cs](files/PhotonRigidbody2DView_cs.md) | Class | Photon.Pun |  |
| [PhotonRigidbodyView](files/PhotonRigidbodyView_cs.md#PhotonRigidbodyView) | [PhotonRigidbodyView.cs](files/PhotonRigidbodyView_cs.md) | Class | Photon.Pun |  |
| [PhotonStreamQueue](files/PhotonStreamQueue_cs.md#PhotonStreamQueue) | [PhotonStreamQueue.cs](files/PhotonStreamQueue_cs.md) | Class | Photon.Pun | The PhotonStreamQueue helps you poll object states at higher frequencies than what |
| [PhotonTransformView](files/PhotonTransformView_cs.md#PhotonTransformView) | [PhotonTransformView.cs](files/PhotonTransformView_cs.md) | Class | Photon.Pun |  |
| [PhotonTransformViewClassic](files/PhotonTransformViewClassic_cs.md#PhotonTransformViewClassic) | [PhotonTransformViewClassic.cs](files/PhotonTransformViewClassic_cs.md) | Class | Photon.Pun | This class helps you to synchronize position, rotation and scale |
| [PhotonView](files/PhotonView_cs.md#PhotonView) | [PhotonView.cs](files/PhotonView_cs.md) | Class | Photon.Pun | A PhotonView identifies an object across the network (viewID) and configures how the controlling client updates remote instances. |
| [ServerSettings](files/ServerSettings_cs.md#ServerSettings) | [ServerSettings.cs](files/ServerSettings_cs.md) | Class | Photon.Pun | Collection of connection-relevant settings, used internally by PhotonNetwork.ConnectUsingSettings. |
| [WebRpcImplementationExample](files/WebRpcImplementationExample_cs.md#WebRpcImplementationExample) | [WebRpcImplementationExample.cs](files/WebRpcImplementationExample_cs.md) | Class | Photon.Pun.Demo | This class is a sample of how to implement WebRPCs calling & callbacks. |
| [Asteroid](files/Asteroid_cs.md#Asteroid) | [Asteroid.cs](files/Asteroid_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [AsteroidsGame](files/AsteroidsGame_cs.md#AsteroidsGame) | [AsteroidsGame.cs](files/AsteroidsGame_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [AsteroidsGameManager](files/AsteroidsGameManager_cs.md#AsteroidsGameManager) | [AsteroidsGameManager.cs](files/AsteroidsGameManager_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [Bullet](files/Bullet_cs.md#Bullet) | [Bullet.cs](files/Bullet_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [LobbyMainPanel](files/LobbyMainPanel_cs.md#LobbyMainPanel) | [LobbyMainPanel.cs](files/LobbyMainPanel_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [LobbyTopPanel](files/LobbyTopPanel_cs.md#LobbyTopPanel) | [LobbyTopPanel.cs](files/LobbyTopPanel_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [PlayerListEntry](files/PlayerListEntry_cs.md#PlayerListEntry) | [PlayerListEntry.cs](files/PlayerListEntry_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [PlayerOverviewPanel](files/PlayerOverviewPanel_cs.md#PlayerOverviewPanel) | [PlayerOverviewPanel.cs](files/PlayerOverviewPanel_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [RoomListEntry](files/RoomListEntry_cs.md#RoomListEntry) | [RoomListEntry.cs](files/RoomListEntry_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [Spaceship](files/Spaceship_cs.md#Spaceship) | [Spaceship.cs](files/Spaceship_cs.md) | Class | Photon.Pun.Demo.Asteroids |  |
| [AppVersionProperty](files/AppVersionProperty_cs.md#AppVersionProperty) | [AppVersionProperty.cs](files/AppVersionProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.AppVersion UI property. |
| [AutoSyncSceneToggle](files/AutoSyncSceneToggle_cs.md#AutoSyncSceneToggle) | [AutoSyncSceneToggle.cs](files/AutoSyncSceneToggle_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.AutomaticallySyncScene UI Toggle |
| [BackgroundTimeOutField](files/BackgroundTimeOutField_cs.md#BackgroundTimeOutField) | [BackgroundTimeOutField.cs](files/BackgroundTimeOutField_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.BackgroundTimeout UI InputField. |
| [BestRegionInPrefsProperty](files/BestRegionInPrefsProperty_cs.md#BestRegionInPrefsProperty) | [BestRegionInPrefsProperty.cs](files/BestRegionInPrefsProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.BestRegionSummaryInPreferences UI property. |
| [BoolInputField](files/BoolInputField_cs.md#BoolInputField) | [BoolInputField.cs](files/BoolInputField_cs.md) | Class | Photon.Pun.Demo.Cockpit | Boolean UI UI Toggle input. |
| [CloudRegionProperty](files/CloudRegionProperty_cs.md#CloudRegionProperty) | [CloudRegionProperty.cs](files/CloudRegionProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CloudRegion UI property. |
| [CountOfPlayersInRoomProperty](files/CountOfPlayersInRoomProperty_cs.md#CountOfPlayersInRoomProperty) | [CountOfPlayersInRoomProperty.cs](files/CountOfPlayersInRoomProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CountOfPlayersInRooms UI property. |
| [CountOfPlayersOnMasterProperty](files/CountOfPlayersOnMasterProperty_cs.md#CountOfPlayersOnMasterProperty) | [CountOfPlayersOnMasterProperty.cs](files/CountOfPlayersOnMasterProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CountOfPlayersOnMaster UI property. |
| [CountOfPlayersProperty](files/CountOfPlayersProperty_cs.md#CountOfPlayersProperty) | [CountOfPlayersProperty.cs](files/CountOfPlayersProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CountOfPlayers UI property. |
| [CountOfRoomsProperty](files/CountOfRoomsProperty_cs.md#CountOfRoomsProperty) | [CountOfRoomsProperty.cs](files/CountOfRoomsProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CountOfRooms UIs property. |
| [CrcCheckToggle](files/CrcCheckToggle_cs.md#CrcCheckToggle) | [CrcCheckToggle.cs](files/CrcCheckToggle_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CrcCheckEnabled UI Toggle |
| [CurrentRoomAutoCleanupProperty](files/CurrentRoomAutoCleanupProperty_cs.md#CurrentRoomAutoCleanupProperty) | [CurrentRoomAutoCleanupProperty.cs](files/CurrentRoomAutoCleanupProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.AutoCleanUp UI property. |
| [CurrentRoomEmptyRoomTtlProperty](files/CurrentRoomEmptyRoomTtlProperty_cs.md#CurrentRoomEmptyRoomTtlProperty) | [CurrentRoomEmptyRoomTtlProperty.cs](files/CurrentRoomEmptyRoomTtlProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.EmptyRoomTtl UI property. |
| [CurrentRoomExpectedUsersProperty](files/CurrentRoomExpectedUsersProperty_cs.md#CurrentRoomExpectedUsersProperty) | [CurrentRoomExpectedUsersProperty.cs](files/CurrentRoomExpectedUsersProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.ExpectedUsers UI property. |
| [CurrentRoomIsOfflineProperty](files/CurrentRoomIsOfflineProperty_cs.md#CurrentRoomIsOfflineProperty) | [CurrentRoomIsOfflineProperty.cs](files/CurrentRoomIsOfflineProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.IsOffline UI property |
| [CurrentRoomIsOpenProperty](files/CurrentRoomIsOpenProperty_cs.md#CurrentRoomIsOpenProperty) | [CurrentRoomIsOpenProperty.cs](files/CurrentRoomIsOpenProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.IsOpen UI property. |
| [CurrentRoomIsOpenToggle](files/CurrentRoomIsOpenToggle_cs.md#CurrentRoomIsOpenToggle) | [CurrentRoomIsOpenToggle.cs](files/CurrentRoomIsOpenToggle_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.IsOpen UI Toggle |
| [CurrentRoomIsVisibleProperty](files/CurrentRoomIsVisibleProperty_cs.md#CurrentRoomIsVisibleProperty) | [CurrentRoomIsVisibleProperty.cs](files/CurrentRoomIsVisibleProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.IsVisible UI property |
| [CurrentRoomIsVisibleToggle](files/CurrentRoomIsVisibleToggle_cs.md#CurrentRoomIsVisibleToggle) | [CurrentRoomIsVisibleToggle.cs](files/CurrentRoomIsVisibleToggle_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.IsVisible UI Toggle |
| [CurrentRoomMasterClientIdProperty](files/CurrentRoomMasterClientIdProperty_cs.md#CurrentRoomMasterClientIdProperty) | [CurrentRoomMasterClientIdProperty.cs](files/CurrentRoomMasterClientIdProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.MasterClientId UI property. |
| [CurrentRoomMaxPlayersProperty](files/CurrentRoomMaxPlayersProperty_cs.md#CurrentRoomMaxPlayersProperty) | [CurrentRoomMaxPlayersProperty.cs](files/CurrentRoomMaxPlayersProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.MaxPlayers UI property. |
| [CurrentRoomNameProperty](files/CurrentRoomNameProperty_cs.md#CurrentRoomNameProperty) | [CurrentRoomNameProperty.cs](files/CurrentRoomNameProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.Name UI property. |
| [CurrentRoomPlayerCountProperty](files/CurrentRoomPlayerCountProperty_cs.md#CurrentRoomPlayerCountProperty) | [CurrentRoomPlayerCountProperty.cs](files/CurrentRoomPlayerCountProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.PlayerCount UI property. |
| [CurrentRoomPlayerTtlProperty](files/CurrentRoomPlayerTtlProperty_cs.md#CurrentRoomPlayerTtlProperty) | [CurrentRoomPlayerTtlProperty.cs](files/CurrentRoomPlayerTtlProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.PlayerTtl UI property. |
| [CurrentRoomPropertiesListedInLobbyProperty](files/CurrentRoomPropertiesListedInLobbyProperty_cs.md#CurrentRoomPropertiesListedInLobbyProperty) | [CurrentRoomPropertiesListedInLobbyProperty.cs](files/CurrentRoomPropertiesListedInLobbyProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.CurrentRoom.PropertiesListedInLobby UI property. |
| [DocLinkButton](files/DocLinkButton_cs.md#DocLinkButton) | [DocLinkButton.cs](files/DocLinkButton_cs.md) | Class | Photon.Pun.Demo.Cockpit | Open an Url on Pointer Click. |
| [FriendListCell](files/FriendListCell_cs.md#FriendListCell) | [FriendListCell.cs](files/FriendListCell_cs.md) | Class | Photon.Pun.Demo.Cockpit | Friend list cell |
| [FriendListView](files/FriendListView_cs.md#FriendListView) | [FriendListView.cs](files/FriendListView_cs.md) | Class | Photon.Pun.Demo.Cockpit | Friend list UI view. |
| [GameVersionField](files/GameVersionField_cs.md#GameVersionField) | [GameVersionField.cs](files/GameVersionField_cs.md) | Class | Photon.Pun.Demo.Cockpit | Game version field. |
| [GameVersionProperty](files/GameVersionProperty_cs.md#GameVersionProperty) | [GameVersionProperty.cs](files/GameVersionProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.GameVersion UI property. |
| [InfosPanelPlaceholder](files/InfosPanelPlaceholder_cs.md#InfosPanelPlaceholder) | [InfosPanelPlaceholder.cs](files/InfosPanelPlaceholder_cs.md) | Class | Photon.Pun.Demo.Cockpit | Infos panel placeholder. Defines the place where the infos panel should go. It will request InfoPanel when Component is enabled. |
| [IntInputField](files/IntInputField_cs.md#IntInputField) | [IntInputField.cs](files/IntInputField_cs.md) | Class | Photon.Pun.Demo.Cockpit | Int UI InputField. |
| [IsConnectedAndReadyProperty](files/IsConnectedAndReadyProperty_cs.md#IsConnectedAndReadyProperty) | [IsConnectedAndReadyProperty.cs](files/IsConnectedAndReadyProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.IsConnectedAndReady UI property |
| [IsConnectedProperty](files/IsConnectedProperty_cs.md#IsConnectedProperty) | [IsConnectedProperty.cs](files/IsConnectedProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.IsConnected UI property |
| [LayoutElementMatchSize](files/LayoutElementMatchSize_cs.md#LayoutElementMatchSize) | [LayoutElementMatchSize.cs](files/LayoutElementMatchSize_cs.md) | Class | Photon.Pun.Demo.Cockpit | Force a LayoutElement to march a RectTransform sizeDelta. Useful for complex child content |
| [NickNameField](files/NickNameField_cs.md#NickNameField) | [NickNameField.cs](files/NickNameField_cs.md) | Class | Photon.Pun.Demo.Cockpit | Nickname InputField. |
| [OfflineModeProperty](files/OfflineModeProperty_cs.md#OfflineModeProperty) | [OfflineModeProperty.cs](files/OfflineModeProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.OfflineMode UI property |
| [OnlineDocButton](files/OnlineDocButton_cs.md#OnlineDocButton) | [OnlineDocButton.cs](files/OnlineDocButton_cs.md) | Class | Photon.Pun.Demo.Cockpit | Open an Url on Pointer Click. |
| [PingProperty](files/PingProperty_cs.md#PingProperty) | [PingProperty.cs](files/PingProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.GetPing() UI property. |
| [PlayerDetailsController](files/PlayerDetailsController_cs.md#PlayerDetailsController) | [PlayerDetailsController.cs](files/PlayerDetailsController_cs.md) | Class | Photon.Pun.Demo.Cockpit | Controller for the Playerdetails UI view |
| [PlayerListCell](files/PlayerListCell_cs.md#PlayerListCell) | [PlayerListCell.cs](files/PlayerListCell_cs.md) | Class | Photon.Pun.Demo.Cockpit | Player list cell representing a given PhotonPlayer |
| [PlayerListView](files/PlayerListView_cs.md#PlayerListView) | [PlayerListView.cs](files/PlayerListView_cs.md) | Class | Photon.Pun.Demo.Cockpit | Player list UI View. |
| [PropertyCell](files/PropertyCell_cs.md#PropertyCell) | [PropertyCell.cs](files/PropertyCell_cs.md) | Class | Photon.Pun.Demo.Cockpit | Generic string Property Cell. |
| [PropertyListenerBase](files/PropertyListenerBase_cs.md#PropertyListenerBase) | [PropertyListenerBase.cs](files/PropertyListenerBase_cs.md) | Class | Photon.Pun.Demo.Cockpit | Property listener base. |
| [PunCockpit](files/PunCockpit_cs.md#PunCockpit) | [PunCockpit.cs](files/PunCockpit_cs.md) | Class | Photon.Pun.Demo.Cockpit | UI based work in progress to test out api and act as foundation when dealing with room, friends and player list |
| [PunCockpitEmbed](files/PunCockpitEmbed_cs.md#PunCockpitEmbed) | [PunCockpitEmbed.cs](files/PunCockpitEmbed_cs.md) | Class | Photon.Pun.Demo.Cockpit | Use this in scenes you want to leave Control for connection and pun related commands to Cockpit. |
| [RegionListCell](files/RegionListCell_cs.md#RegionListCell) | [RegionListCell.cs](files/RegionListCell_cs.md) | Class | Photon.Pun.Demo.Cockpit | Region list cell. |
| [RegionListView](files/RegionListView_cs.md#RegionListView) | [RegionListView.cs](files/RegionListView_cs.md) | Class | Photon.Pun.Demo.Cockpit | Region list UI View. |
| [RoomListCell](files/RoomListCell_cs.md#RoomListCell) | [RoomListCell.cs](files/RoomListCell_cs.md) | Class | Photon.Pun.Demo.Cockpit | Roomlist cell. |
| [RoomListView](files/RoomListView_cs.md#RoomListView) | [RoomListView.cs](files/RoomListView_cs.md) | Class | Photon.Pun.Demo.Cockpit | Room list UI View. |
| [ScoreHelper](files/ScoreHelper_cs.md#ScoreHelper) | [ScoreHelper.cs](files/ScoreHelper_cs.md) | Class | Photon.Pun.Demo.Cockpit |  |
| [SendRateField](files/SendRateField_cs.md#SendRateField) | [SendRateField.cs](files/SendRateField_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.SendRate InputField. |
| [SendRateOnSerializeField](files/SendRateOnSerializeField_cs.md#SendRateOnSerializeField) | [SendRateOnSerializeField.cs](files/SendRateOnSerializeField_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.SerializationRate InputField |
| [ServerAddressProperty](files/ServerAddressProperty_cs.md#ServerAddressProperty) | [ServerAddressProperty.cs](files/ServerAddressProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.ServerAddress UI property. |
| [ServerProperty](files/ServerProperty_cs.md#ServerProperty) | [ServerProperty.cs](files/ServerProperty_cs.md) | Class | Photon.Pun.Demo.Cockpit | PhotonNetwork.Server UI property |
| [StringInputField](files/StringInputField_cs.md#StringInputField) | [StringInputField.cs](files/StringInputField_cs.md) | Class | Photon.Pun.Demo.Cockpit | String UI InputField. |
| [ToggleExpand](files/ToggleExpand_cs.md#ToggleExpand) | [ToggleExpand.cs](files/ToggleExpand_cs.md) | Class | Photon.Pun.Demo.Cockpit | UI toggle to activate GameObject. |
| [UserIdField](files/UserIdField_cs.md#UserIdField) | [UserIdField.cs](files/UserIdField_cs.md) | Class | Photon.Pun.Demo.Cockpit | User identifier InputField. |
| [ConnectToRegionUIForm](files/ConnectToRegionUIForm_cs.md#ConnectToRegionUIForm) | [ConnectToRegionUIForm.cs](files/ConnectToRegionUIForm_cs.md) | Class | Photon.Pun.Demo.Cockpit.Forms | Manager for ConnectToRegion UI Form |
| [CreateRoomUiForm](files/CreateRoomUiForm_cs.md#CreateRoomUiForm) | [CreateRoomUiForm.cs](files/CreateRoomUiForm_cs.md) | Class | Photon.Pun.Demo.Cockpit.Forms | Create room user interface form. |
| [LoadLevelUIForm](files/LoadLevelUIForm_cs.md#LoadLevelUIForm) | [LoadLevelUIForm.cs](files/LoadLevelUIForm_cs.md) | Class | Photon.Pun.Demo.Cockpit.Forms | Level Loading UI Form. |
| [SetRoomCustomPropertyUIForm](files/SetRoomCustomPropertyUIForm_cs.md#SetRoomCustomPropertyUIForm) | [SetRoomCustomPropertyUIForm.cs](files/SetRoomCustomPropertyUIForm_cs.md) | Class | Photon.Pun.Demo.Cockpit.Forms | Room custom properties UI Form. |
| [UserIdUiForm](files/UserIdUiForm_cs.md#UserIdUiForm) | [UserIdUiForm.cs](files/UserIdUiForm_cs.md) | Class | Photon.Pun.Demo.Cockpit.Forms | User Id UI form. |
| [DemoHubManager](files/DemoHubManager_cs.md#DemoHubManager) | [DemoHubManager.cs](files/DemoHubManager_cs.md) | Class | Photon.Pun.Demo.Hub |  |
| [ToDemoHubButton](files/ToDemoHubButton_cs.md#ToDemoHubButton) | [ToDemoHubButton.cs](files/ToDemoHubButton_cs.md) | Class | Photon.Pun.Demo.Hub | Present a button on all launched demos from hub to allow getting back to the demo hub. |
| [Block](files/Block_cs.md#Block) | [Block.cs](files/Block_cs.md) | Class | Photon.Pun.Demo.Procedural | The Block component is attach to each instantiated Block at runtime. |
| [Cluster](files/Cluster_cs.md#Cluster) | [Cluster.cs](files/Cluster_cs.md) | Class | Photon.Pun.Demo.Procedural | The Cluster component has references to all Blocks that are part of this Cluster. |
| [IngameControlPanel](files/IngameControlPanel_cs.md#IngameControlPanel) | [IngameControlPanel.cs](files/IngameControlPanel_cs.md) | Class | Photon.Pun.Demo.Procedural | The Ingame Control Panel basically controls the WorldGenerator. |
| [ProceduralController](files/ProceduralController_cs.md#ProceduralController) | [ProceduralController.cs](files/ProceduralController_cs.md) | Class | Photon.Pun.Demo.Procedural | Simple Input Handler to control the camera. |
| [WorldGenerator](files/WorldGenerator_cs.md#WorldGenerator) | [WorldGenerator.cs](files/WorldGenerator_cs.md) | Class | Photon.Pun.Demo.Procedural | The World Generator creates a world based on four options the current MasterClient can set. |
| [CameraWork](files/CameraWork_cs.md#CameraWork) | [CameraWork.cs](files/CameraWork_cs.md) | Class | Photon.Pun.Demo.PunBasics | Camera work. Follow a target |
| [GameManager](files/GameManager_cs.md#GameManager) | [GameManager.cs](files/GameManager_cs.md) | Class | Photon.Pun.Demo.PunBasics | Game manager. |
| [Launcher](files/Launcher_cs.md#Launcher) | [Launcher.cs](files/Launcher_cs.md) | Class | Photon.Pun.Demo.PunBasics | Launch manager. Connect, join a random room or create one if none or all full. |
| [LoaderAnime](files/LoaderAnime_cs.md#LoaderAnime) | [LoaderAnime.cs](files/LoaderAnime_cs.md) | Class | Photon.Pun.Demo.PunBasics | Simple behaviour to animate particles around to create a typical "Ajax Loader". this is actually very important to visual inform the user that something is happening |
| [PlayerAnimatorManager](files/PlayerAnimatorManager_cs.md#PlayerAnimatorManager) | [PlayerAnimatorManager.cs](files/PlayerAnimatorManager_cs.md) | Class | Photon.Pun.Demo.PunBasics |  |
| [PlayerManager](files/PlayerManager_cs.md#PlayerManager) | [PlayerManager.cs](files/PlayerManager_cs.md) | Class | Photon.Pun.Demo.PunBasics | Player manager. |
| [PlayerNameInputField](files/PlayerNameInputField_cs.md#PlayerNameInputField) | [PlayerNameInputField.cs](files/PlayerNameInputField_cs.md) | Class | Photon.Pun.Demo.PunBasics | Player name input field. Let the user input his name, will appear above the player in the game. |
| [PlayerUI](files/PlayerUI_cs.md#PlayerUI) | [PlayerUI.cs](files/PlayerUI_cs.md) | Class | Photon.Pun.Demo.PunBasics | Player UI. Constraint the UI to follow a PlayerManager GameObject in the world, |
| [DocLinks](files/DocLinks_cs.md#DocLinks) | [DocLinks.cs](files/DocLinks_cs.md) | Class | Photon.Pun.Demo.Shared | Document links. |
| [PlayerControl](files/PlayerControl_cs.md#PlayerControl) | [PlayerControl.cs](files/PlayerControl_cs.md) | Class | Photon.Pun.Demo.SlotRacer | Player control. |
| [SlotLanes](files/SlotLanes_cs.md#SlotLanes) | [SlotLanes.cs](files/SlotLanes_cs.md) | Class | Photon.Pun.Demo.SlotRacer | Define Slot lanes and grid positions placeholders. |
| [SlotRacerSplashScreen](files/SlotRacerSplashScreen_cs.md#SlotRacerSplashScreen) | [SlotRacerSplashScreen.cs](files/SlotRacerSplashScreen_cs.md) | Class | Photon.Pun.Demo.SlotRacer | Slot racer splash screen. Inform about the slotRacer demo and the Cockpit control setup |
| [Bezier](files/Bezier_cs.md#Bezier) | [Bezier.cs](files/Bezier_cs.md) | Class | Photon.Pun.Demo.SlotRacer.Utils |  |
| [BezierCurve](files/BezierCurve_cs.md#BezierCurve) | [BezierCurve.cs](files/BezierCurve_cs.md) | Class | Photon.Pun.Demo.SlotRacer.Utils |  |
| [BezierSpline](files/BezierSpline_cs.md#BezierSpline) | [BezierSpline.cs](files/BezierSpline_cs.md) | Class | Photon.Pun.Demo.SlotRacer.Utils |  |
| [Line](files/Line_cs.md#Line) | [Line.cs](files/Line_cs.md) | Class | Photon.Pun.Demo.SlotRacer.Utils |  |
| [SplinePosition](files/SplinePosition_cs.md#SplinePosition) | [SplinePosition.cs](files/SplinePosition_cs.md) | Class | Photon.Pun.Demo.SlotRacer.Utils |  |
| [SplineWalker](files/SplineWalker_cs.md#SplineWalker) | [SplineWalker.cs](files/SplineWalker_cs.md) | Class | Photon.Pun.Demo.SlotRacer.Utils |  |
| [ButtonInsideScrollList](files/ButtonInsideScrollList_cs.md#ButtonInsideScrollList) | [ButtonInsideScrollList.cs](files/ButtonInsideScrollList_cs.md) | Class | Photon.Pun.UtilityScripts | Button inside scroll list will stop scrolling ability of scrollRect container, so that when pressing down on a button and draggin up and down will not affect scrolling. |
| [ConnectAndJoinRandom](files/ConnectAndJoinRandom_cs.md#ConnectAndJoinRandom) | [ConnectAndJoinRandom.cs](files/ConnectAndJoinRandom_cs.md) | Class | Photon.Pun.UtilityScripts | Simple component to call ConnectUsingSettings and to get into a PUN room easily. |
| [CountdownTimer](files/CountdownTimer_cs.md#CountdownTimer) | [CountdownTimer.cs](files/CountdownTimer_cs.md) | Class | Photon.Pun.UtilityScripts | This is a basic, network-synced CountdownTimer based on properties. |
| [CullArea](files/CullArea_cs.md#CullArea) | [CullArea.cs](files/CullArea_cs.md) | Class | Photon.Pun.UtilityScripts | Represents the cull area used for network culling. |
| [CullingHandler](files/CullingHandler_cs.md#CullingHandler) | [CullingHandler.cs](files/CullingHandler_cs.md) | Class | Photon.Pun.UtilityScripts | Handles the network culling. |
| [EventSystemSpawner](files/EventSystemSpawner_cs.md#EventSystemSpawner) | [EventSystemSpawner.cs](files/EventSystemSpawner_cs.md) | Class | Photon.Pun.UtilityScripts | Event system spawner. Will add an EventSystem GameObject with an EventSystem component and a StandaloneInputModule component. |
| [GraphicToggleIsOnTransition](files/GraphicToggleIsOnTransition_cs.md#GraphicToggleIsOnTransition) | [GraphicToggleIsOnTransition.cs](files/GraphicToggleIsOnTransition_cs.md) | Class | Photon.Pun.UtilityScripts | Use this on toggles texts to have some color transition on the text depending on the isOn State. |
| [MoveByKeys](files/MoveByKeys_cs.md#MoveByKeys) | [MoveByKeys.cs](files/MoveByKeys_cs.md) | Class | Photon.Pun.UtilityScripts | Very basic component to move a GameObject by WASD and Space. |
| [OnClickDestroy](files/OnClickDestroy_cs.md#OnClickDestroy) | [OnClickDestroy.cs](files/OnClickDestroy_cs.md) | Class | Photon.Pun.UtilityScripts | Destroys the networked GameObject either by PhotonNetwork.Destroy or by sending an RPC which calls Object.Destroy(). |
| [OnClickInstantiate](files/OnClickInstantiate_cs.md#OnClickInstantiate) | [OnClickInstantiate.cs](files/OnClickInstantiate_cs.md) | Class | Photon.Pun.UtilityScripts | Instantiates a networked GameObject on click. |
| [OnClickRpc](files/OnClickRpc_cs.md#OnClickRpc) | [OnClickRpc.cs](files/OnClickRpc_cs.md) | Class | Photon.Pun.UtilityScripts | This component will instantiate a network GameObject when in a room and the user click on that component's GameObject. |
| [OnEscapeQuit](files/OnEscapeQuit_cs.md#OnEscapeQuit) | [OnEscapeQuit.cs](files/OnEscapeQuit_cs.md) | Class | Photon.Pun.UtilityScripts | This component will quit the application when escape key is pressed |
| [OnJoinedInstantiate](files/OnJoinedInstantiate_cs.md#OnJoinedInstantiate) | [OnJoinedInstantiate.cs](files/OnJoinedInstantiate_cs.md) | Class | Photon.Pun.UtilityScripts | This component will instantiate a network GameObject when a room is joined |
| [OnPointerOverTooltip](files/OnPointerOverTooltip_cs.md#OnPointerOverTooltip) | [OnPointerOverTooltip.cs](files/OnPointerOverTooltip_cs.md) | Class | Photon.Pun.UtilityScripts | Set focus to a given photonView when pointed is over |
| [OnStartDelete](files/OnStartDelete_cs.md#OnStartDelete) | [OnStartDelete.cs](files/OnStartDelete_cs.md) | Class | Photon.Pun.UtilityScripts | This component will destroy the GameObject it is attached to (in Start()). |
| [PhotonLagSimulationGui](files/PhotonLagSimulationGui_cs.md#PhotonLagSimulationGui) | [PhotonLagSimulationGui.cs](files/PhotonLagSimulationGui_cs.md) | Class | Photon.Pun.UtilityScripts | This MonoBehaviour is a basic GUI for the Photon client's network-simulation feature. |
| [PhotonStatsGui](files/PhotonStatsGui_cs.md#PhotonStatsGui) | [PhotonStatsGui.cs](files/PhotonStatsGui_cs.md) | Class | Photon.Pun.UtilityScripts | Basic GUI to show traffic and health statistics of the connection to Photon, |
| [PhotonTeamsManager](files/PhotonTeamsManager_cs.md#PhotonTeamsManager) | [PhotonTeamsManager.cs](files/PhotonTeamsManager_cs.md) | Class | Photon.Pun.UtilityScripts | Implements teams in a room/game with help of player properties. Access them by Player.GetTeam extension. |
| [PlayerNumbering](files/PlayerNumbering_cs.md#PlayerNumbering) | [PlayerNumbering.cs](files/PlayerNumbering_cs.md) | Class | Photon.Pun.UtilityScripts | Implements consistent numbering in a room/game with help of room properties. Access them by Player.GetPlayerNumber() extension. |
| [PointedAtGameObjectInfo](files/PointedAtGameObjectInfo_cs.md#PointedAtGameObjectInfo) | [PointedAtGameObjectInfo.cs](files/PointedAtGameObjectInfo_cs.md) | Class | Photon.Pun.UtilityScripts | Display ViewId, OwnerActorNr, IsCeneView and IsMine when clicked. |
| [PunPlayerScores](files/PunPlayerScores_cs.md#PunPlayerScores) | [PunPlayerScores.cs](files/PunPlayerScores_cs.md) | Class | Photon.Pun.UtilityScripts | Scoring system for PhotonPlayer |
| [PunTeams](files/PunTeams_cs.md#PunTeams) | [PunTeams.cs](files/PunTeams_cs.md) | Class | Photon.Pun.UtilityScripts | Implements teams in a room/game with help of player properties. Access them by Player.GetTeam extension. |
| [PunTurnManager](files/PunTurnManager_cs.md#PunTurnManager) | [PunTurnManager.cs](files/PunTurnManager_cs.md) | Class | Photon.Pun.UtilityScripts | Pun turnBased Game manager. |
| [SmoothSyncMovement](files/SmoothSyncMovement_cs.md#SmoothSyncMovement) | [SmoothSyncMovement.cs](files/SmoothSyncMovement_cs.md) | Class | Photon.Pun.UtilityScripts | Smoothed out movement for network gameobjects |
| [StatesGui](files/StatesGui_cs.md#StatesGui) | [StatesGui.cs](files/StatesGui_cs.md) | Class | Photon.Pun.UtilityScripts | Output detailed information about Pun Current states, using the old Unity UI framework. |
| [TabViewManager](files/TabViewManager_cs.md#TabViewManager) | [TabViewManager.cs](files/TabViewManager_cs.md) | Class | Photon.Pun.UtilityScripts | Tab view manager. Handles Tab views activation and deactivation, and provides a Unity Event Callback when a tab was selected. |
| [TextButtonTransition](files/TextButtonTransition_cs.md#TextButtonTransition) | [TextButtonTransition.cs](files/TextButtonTransition_cs.md) | Class | Photon.Pun.UtilityScripts | Use this on Button texts to have some color transition on the text as well without corrupting button's behaviour. |
| [TextToggleIsOnTransition](files/TextToggleIsOnTransition_cs.md#TextToggleIsOnTransition) | [TextToggleIsOnTransition.cs](files/TextToggleIsOnTransition_cs.md) | Class | Photon.Pun.UtilityScripts | Use this on toggles texts to have some color transition on the text depending on the isOn State. |
| [AppSettings](files/AppSettings_cs.md#AppSettings) | [AppSettings.cs](files/AppSettings_cs.md) | Class | Photon.Realtime | Settings for Photon application(s) and the server to connect to. |
| [ConnectionHandler](files/ConnectionHandler_cs.md#ConnectionHandler) | [ConnectionHandler.cs](files/ConnectionHandler_cs.md) | Class | Photon.Realtime |  |
| [CustomTypesUnity](files/CustomTypesUnity_cs.md#CustomTypesUnity) | [CustomTypesUnity.cs](files/CustomTypesUnity_cs.md) | Class | Photon.Realtime | Internally used class, containing de/serialization methods for various Unity-specific classes. |
| [Extensions](files/Extensions_cs.md#Extensions) | [Extensions.cs](files/Extensions_cs.md) | Class | Photon.Realtime | This static class defines some useful extension methods for several existing classes (e.g. Vector3, float and others). |
| [FriendInfo](files/FriendInfo_cs.md#FriendInfo) | [FriendInfo.cs](files/FriendInfo_cs.md) | Class | Photon.Realtime | Used to store info about a friend's online state and in which room he/she is. |
| [LoadBalancingClient](files/LoadBalancingClient_cs.md#LoadBalancingClient) | [LoadBalancingClient.cs](files/LoadBalancingClient_cs.md) | Class | Photon.Realtime | This class implements the Photon LoadBalancing workflow by using a LoadBalancingPeer. |
| [PhotonPing](files/PhotonPing_cs.md#PhotonPing) | [PhotonPing.cs](files/PhotonPing_cs.md) | Class | Photon.Realtime | Abstract implementation of PhotonPing, ase for pinging servers to find the "Best Region". |
| [Player](files/Player_cs.md#Player) | [Player.cs](files/Player_cs.md) | Class | Photon.Realtime | Summarizes a "player" within a room, identified (in that room) by ID (or "actorNumber"). |
| [Region](files/Region_cs.md#Region) | [Region.cs](files/Region_cs.md) | Class | Photon.Realtime |  |
| [RegionHandler](files/RegionHandler_cs.md#RegionHandler) | [RegionHandler.cs](files/RegionHandler_cs.md) | Class | Photon.Realtime | Provides methods to work with Photon's regions (Photon Cloud) and can be use to find the one with best ping. |
| [Room](files/Room_cs.md#Room) | [Room.cs](files/Room_cs.md) | Class | Photon.Realtime | This class represents a room a client joins/joined. |
| [RoomInfo](files/RoomInfo_cs.md#RoomInfo) | [RoomInfo.cs](files/RoomInfo_cs.md) | Class | Photon.Realtime | A simplified room with just the info required to list and join, used for the room listing in the lobby. |
| [SupportLogger](files/SupportLogger_cs.md#SupportLogger) | [SupportLogger.cs](files/SupportLogger_cs.md) | Class | Photon.Realtime | Helper class to debug log basic information about Photon client and vital traffic statistics. |
| [SystemConnectionSummary](files/SystemConnectionSummary_cs.md#SystemConnectionSummary) | [SystemConnectionSummary.cs](files/SystemConnectionSummary_cs.md) | Class | Photon.Realtime | The SystemConnectionSummary (SBS) is useful to analyze low level connection issues in Unity. This requires a ConnectionHandler in the scene. |
| [ConnectAndJoinRandomLb](files/ConnectAndJoinRandomLb_cs.md#ConnectAndJoinRandomLb) | [ConnectAndJoinRandomLb.cs](files/ConnectAndJoinRandomLb_cs.md) | Class | Photon.Realtime.Demo |  |
| [Noise](files/Noise_cs.md#Noise) | [Noise.cs](files/Noise_cs.md) | Class | Simplex | Implementation of the Perlin simplex noise, an improved Perlin noise algorithm. |
| [TMP_DigitValidator](files/TMP_DigitValidator_cs.md#TMP_DigitValidator) | [TMP_DigitValidator.cs](files/TMP_DigitValidator_cs.md) | Class | TMPro | EXample of a Custom Character Input Validator to only allow digits from 0 to 9. |
| [TMP_PhoneNumberValidator](files/TMP_PhoneNumberValidator_cs.md#TMP_PhoneNumberValidator) | [TMP_PhoneNumberValidator.cs](files/TMP_PhoneNumberValidator_cs.md) | Class | TMPro | Example of a Custom Character Input Validator to only allow phone number in the (800) 555-1212 format. |
| [TMP_TextEventHandler](files/TMP_TextEventHandler_cs.md#TMP_TextEventHandler) | [TMP_TextEventHandler.cs](files/TMP_TextEventHandler_cs.md) | Class | TMPro |  |
| [Benchmark01](files/Benchmark01_cs.md#Benchmark01) | [Benchmark01.cs](files/Benchmark01_cs.md) | Class | TMPro.Examples |  |
| [Benchmark01_UGUI](files/Benchmark01_UGUI_cs.md#Benchmark01_UGUI) | [Benchmark01_UGUI.cs](files/Benchmark01_UGUI_cs.md) | Class | TMPro.Examples |  |
| [Benchmark02](files/Benchmark02_cs.md#Benchmark02) | [Benchmark02.cs](files/Benchmark02_cs.md) | Class | TMPro.Examples |  |
| [Benchmark03](files/Benchmark03_cs.md#Benchmark03) | [Benchmark03.cs](files/Benchmark03_cs.md) | Class | TMPro.Examples |  |
| [Benchmark04](files/Benchmark04_cs.md#Benchmark04) | [Benchmark04.cs](files/Benchmark04_cs.md) | Class | TMPro.Examples |  |
| [CameraController](files/CameraController_cs.md#CameraController) | [CameraController.cs](files/CameraController_cs.md) | Class | TMPro.Examples |  |
| [ObjectSpin](files/ObjectSpin_cs.md#ObjectSpin) | [ObjectSpin.cs](files/ObjectSpin_cs.md) | Class | TMPro.Examples |  |
| [ShaderPropAnimator](files/ShaderPropAnimator_cs.md#ShaderPropAnimator) | [ShaderPropAnimator.cs](files/ShaderPropAnimator_cs.md) | Class | TMPro.Examples |  |
| [SimpleScript](files/SimpleScript_cs.md#SimpleScript) | [SimpleScript.cs](files/SimpleScript_cs.md) | Class | TMPro.Examples |  |
| [SkewTextExample](files/SkewTextExample_cs.md#SkewTextExample) | [SkewTextExample.cs](files/SkewTextExample_cs.md) | Class | TMPro.Examples |  |
| [TeleType](files/TeleType_cs.md#TeleType) | [TeleType.cs](files/TeleType_cs.md) | Class | TMPro.Examples |  |
| [TextConsoleSimulator](files/TextConsoleSimulator_cs.md#TextConsoleSimulator) | [TextConsoleSimulator.cs](files/TextConsoleSimulator_cs.md) | Class | TMPro.Examples |  |
| [TextMeshProFloatingText](files/TextMeshProFloatingText_cs.md#TextMeshProFloatingText) | [TextMeshProFloatingText.cs](files/TextMeshProFloatingText_cs.md) | Class | TMPro.Examples |  |
| [TextMeshSpawner](files/TextMeshSpawner_cs.md#TextMeshSpawner) | [TextMeshSpawner.cs](files/TextMeshSpawner_cs.md) | Class | TMPro.Examples |  |
| [TMP_ExampleScript_01](files/TMP_ExampleScript_01_cs.md#TMP_ExampleScript_01) | [TMP_ExampleScript_01.cs](files/TMP_ExampleScript_01_cs.md) | Class | TMPro.Examples |  |
| [TMP_FrameRateCounter](files/TMP_FrameRateCounter_cs.md#TMP_FrameRateCounter) | [TMP_FrameRateCounter.cs](files/TMP_FrameRateCounter_cs.md) | Class | TMPro.Examples |  |
| [TMP_TextEventCheck](files/TMP_TextEventCheck_cs.md#TMP_TextEventCheck) | [TMP_TextEventCheck.cs](files/TMP_TextEventCheck_cs.md) | Class | TMPro.Examples |  |
| [TMP_TextInfoDebugTool](files/TMP_TextInfoDebugTool_cs.md#TMP_TextInfoDebugTool) | [TMP_TextInfoDebugTool.cs](files/TMP_TextInfoDebugTool_cs.md) | Class | TMPro.Examples |  |
| [TMP_TextSelector_A](files/TMP_TextSelector_A_cs.md#TMP_TextSelector_A) | [TMP_TextSelector_A.cs](files/TMP_TextSelector_A_cs.md) | Class | TMPro.Examples |  |
| [TMP_TextSelector_B](files/TMP_TextSelector_B_cs.md#TMP_TextSelector_B) | [TMP_TextSelector_B.cs](files/TMP_TextSelector_B_cs.md) | Class | TMPro.Examples |  |
| [TMP_UiFrameRateCounter](files/TMP_UiFrameRateCounter_cs.md#TMP_UiFrameRateCounter) | [TMP_UiFrameRateCounter.cs](files/TMP_UiFrameRateCounter_cs.md) | Class | TMPro.Examples |  |
| [TMPro_InstructionOverlay](files/TMPro_InstructionOverlay_cs.md#TMPro_InstructionOverlay) | [TMPro_InstructionOverlay.cs](files/TMPro_InstructionOverlay_cs.md) | Class | TMPro.Examples |  |
| [VertexColorCycler](files/VertexColorCycler_cs.md#VertexColorCycler) | [VertexColorCycler.cs](files/VertexColorCycler_cs.md) | Class | TMPro.Examples |  |
| [VertexJitter](files/VertexJitter_cs.md#VertexJitter) | [VertexJitter.cs](files/VertexJitter_cs.md) | Class | TMPro.Examples |  |
| [VertexShakeA](files/VertexShakeA_cs.md#VertexShakeA) | [VertexShakeA.cs](files/VertexShakeA_cs.md) | Class | TMPro.Examples |  |
| [VertexShakeB](files/VertexShakeB_cs.md#VertexShakeB) | [VertexShakeB.cs](files/VertexShakeB_cs.md) | Class | TMPro.Examples |  |
| [VertexZoom](files/VertexZoom_cs.md#VertexZoom) | [VertexZoom.cs](files/VertexZoom_cs.md) | Class | TMPro.Examples |  |
| [WarpTextExample](files/WarpTextExample_cs.md#WarpTextExample) | [WarpTextExample.cs](files/WarpTextExample_cs.md) | Class | TMPro.Examples |  |
| [ThirdPersonCharacter](files/ThirdPersonCharacter_cs.md#ThirdPersonCharacter) | [ThirdPersonCharacter.cs](files/ThirdPersonCharacter_cs.md) | Class | UnityStandardAssets.Characters.ThirdPerson.PunDemos |  |
| [ThirdPersonUserControl](files/ThirdPersonUserControl_cs.md#ThirdPersonUserControl) | [ThirdPersonUserControl.cs](files/ThirdPersonUserControl_cs.md) | Class | UnityStandardAssets.Characters.ThirdPerson.PunDemos |  |
