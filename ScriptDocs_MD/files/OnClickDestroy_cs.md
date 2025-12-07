# File: OnClickDestroy.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/UtilityScripts/Prototyping/OnClickDestroy.cs`

<a id='OnClickDestroy'></a>
## Class OnClickDestroy
**Namespace:** `Photon.Pun.UtilityScripts`<br>
**Signature:** `OnClickDestroy : MonoBehaviourPun, IPointerClickHandler`

> Destroys the networked GameObject either by PhotonNetwork.Destroy or by sending an RPC which calls Object.Destroy().

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Button | `InputButton` |  |  |
| `public` | ModifierKey | `KeyCode` |  |  |
| `public` | DestroyByRpc | `Boolean` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `private` | UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick | PointerEventData eventData | `Void` |  |
| `public` | DestroyRpc |  | `IEnumerator` |  |

---

