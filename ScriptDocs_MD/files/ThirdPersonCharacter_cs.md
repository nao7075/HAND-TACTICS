# File: ThirdPersonCharacter.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/Shared Assets/Scripts/ThirdPersonCharacter.cs`

<a id='ThirdPersonCharacter'></a>
## Class ThirdPersonCharacter
**Namespace:** `UnityStandardAssets.Characters.ThirdPerson.PunDemos`<br>
**Signature:** `ThirdPersonCharacter : MonoBehaviour`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | m_MovingTurnSpeed | `Single` |  |  |
| `private` | m_StationaryTurnSpeed | `Single` |  |  |
| `private` | m_JumpPower | `Single` |  |  |
| `private` | m_GravityMultiplier | `Single` |  | Range(1, 4) |
| `private` | m_RunCycleLegOffset | `Single` | specific to the character in sample assets, will need to be modified to work with others |  |
| `private` | m_MoveSpeedMultiplier | `Single` |  |  |
| `private` | m_AnimSpeedMultiplier | `Single` |  |  |
| `private` | m_GroundCheckDistance | `Single` |  |  |
| `private` | m_Rigidbody | `Rigidbody` |  |  |
| `private` | m_Animator | `Animator` |  |  |
| `private` | m_IsGrounded | `Boolean` |  |  |
| `private` | m_OrigGroundCheckDistance | `Single` |  |  |
| `private` | k_Half | `Single` |  |  |
| `private` | m_TurnAmount | `Single` |  |  |
| `private` | m_ForwardAmount | `Single` |  |  |
| `private` | m_GroundNormal | `Vector3` |  |  |
| `private` | m_CapsuleHeight | `Single` |  |  |
| `private` | m_CapsuleCenter | `Vector3` |  |  |
| `private` | m_Capsule | `CapsuleCollider` |  |  |
| `private` | m_Crouching | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | ⚡ Start |  | `Void` | Unity Event Function |
| `public` | Move | Vector3 move, Boolean crouch, Boolean jump | `Void` |  |
| `private` | ScaleCapsuleForCrouching | Boolean crouch | `Void` |  |
| `private` | PreventStandingInLowHeadroom |  | `Void` |  |
| `private` | UpdateAnimator | Vector3 move | `Void` |  |
| `private` | HandleAirborneMovement |  | `Void` |  |
| `private` | HandleGroundedMovement | Boolean crouch, Boolean jump | `Void` |  |
| `private` | ApplyExtraTurnRotation |  | `Void` |  |
| `public` | OnAnimatorMove |  | `Void` |  |
| `private` | CheckGroundStatus |  | `Void` |  |

---

