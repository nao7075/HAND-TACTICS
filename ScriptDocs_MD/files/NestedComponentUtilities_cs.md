# File: NestedComponentUtilities.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonUnityNetworking_Code_Utilities.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Code/Utilities/NestedComponentUtilities.cs`

<a id='NestedComponentUtilities'></a>
## Class NestedComponentUtilities
**Namespace:** `Photon.Pun`<br>
**Signature:** `NestedComponentUtilities`

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | nodesQueue | `Queue`1` |  |  |
| `public` | searchLists | `Dictionary`2` |  |  |
| `private` | nodeStack | `Stack`1` |  |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S EnsureRootComponentExists | Transform transform | `T` |  |
| `public` | S GetParentComponent | Transform t | `T` |  |
| `public` | S GetNestedComponentsInParents | Transform t, List`1 list | `Void` |  |
| `public` | S GetNestedComponentInChildren | Transform t, Boolean includeInactive | `T` |  |
| `public` | S GetNestedComponentInParent | Transform t | `T` |  |
| `public` | S GetNestedComponentInParents | Transform t | `T` |  |
| `public` | S GetNestedComponentsInParents | Transform t, List`1 list | `Void` |  |
| `public` | S GetNestedComponentsInChildren | Transform t, List`1 list, Boolean includeInactive | `List`1` |  |
| `public` | S GetNestedComponentsInChildren | Transform t, List`1 list, Boolean includeInactive, Type[] stopOn | `List`1` |  |
| `public` | S GetNestedComponentsInChildren | Transform t, Boolean includeInactive, List`1 list | `Void` |  |

---

