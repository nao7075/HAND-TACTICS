# File: OnJoinedInstantiate.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Prototyping/OnJoinedInstantiate.cs`

<a id='OnJoinedInstantiate'></a>
## Class OnJoinedInstantiate
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `OnJoinedInstantiate : MonoBehaviour, IMatchmakingCallbacks`

> This component will instantiate a network GameObject when a room is joined

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | SpawnPosition | `Transform` |  |  |
| `public` | Sequence | `SpawnSequence` |  |  |
| `public` | SpawnPoints | `List`1` |  |  |
| `public` | UseRandomOffset | `Boolean` |  |  |
| `public` | RandomOffset | `Single` |  |  |
| `public` | ClampY | `Boolean` |  |  |
| `public` | PrefabsToInstantiate | `List`1` | set in inspector |  |
| `public` | AutoSpawnObjects | `Boolean` |  |  |
| `public` | SpawnedObjects | `Stack`1` |  |  |
| `protected` | spawnedAsActorId | `Int32` |  |  |
| `protected` | lastUsedSpawnPointIndex | `Int32` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `protected` | ⚡ OnValidate |  | `Void` | Unity Event Function |
| `public` | AddPrefabToList | GameObject prefab | `Boolean` | Validate, and if valid add this prefab to the first null element of the list, or create a new element. Returns true if the object was added. |
| `protected` | S ValidatePrefab | GameObject unvalidated | `GameObject` | Determines if the supplied GameObject is an instance of a prefab, or the actual source Asset,<br>and returns a best guess at the actual resource the dev intended to use. |
| `public` | ⚡ OnEnable |  | `Void` | Unity Event Function |
| `public` | ⚡ OnDisable |  | `Void` | Unity Event Function |
| `public` | OnJoinedRoom |  | `Void` |  |
| `public` | SpawnObjects |  | `Void` |  |
| `public` | DespawnObjects | Boolean localOnly | `Void` | Destroy all objects that have been spawned by this component for this client. |
| `public` | OnFriendListUpdate | List`1 friendList | `Void` |  |
| `public` | OnCreatedRoom |  | `Void` |  |
| `public` | OnCreateRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRoomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnJoinRandomFailed | Int16 returnCode, String message | `Void` |  |
| `public` | OnLeftRoom |  | `Void` |  |
| `public` | GetSpawnPoint | Vector3& spawnPos, Quaternion& spawnRot | `Void` | Gets the next SpawnPoint from the list using the SpawnSequence, and applies RandomOffset (if used) to the transform matrix.<br>Override this method with any custom code for coming up with a spawn location. This method is used by AutoSpawn.<br>Get the transform of the next SpawnPoint from the list, selected using the SpawnSequence setting.<br>RandomOffset is not applied, only the transform of the SpawnPoint is returned.<br>Override this method to change how Spawn Point transform is selected. Return the transform you want to use as a spawn point. |
| `protected` | GetSpawnPoint |  | `Transform` | Gets the next SpawnPoint from the list using the SpawnSequence, and applies RandomOffset (if used) to the transform matrix.<br>Override this method with any custom code for coming up with a spawn location. This method is used by AutoSpawn.<br>Get the transform of the next SpawnPoint from the list, selected using the SpawnSequence setting.<br>RandomOffset is not applied, only the transform of the SpawnPoint is returned.<br>Override this method to change how Spawn Point transform is selected. Return the transform you want to use as a spawn point. |
| `protected` | GetRandomOffset |  | `Vector3` | When UseRandomeOffset is enabled, this method is called to produce a Vector3 offset. The default implementation clamps the Y value to zero. You may override this with your own implementation. |

---

