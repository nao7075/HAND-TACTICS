# File: Extensions.cs
[< トップページ](../index.md) | [< フォルダ一覧](../folders/Assets_Photon_PhotonRealtime_Code.md)

> **Path:** `Assets/Photon/PhotonRealtime/Code/Extensions.cs`

<a id='Extensions'></a>
## Class Extensions
**Namespace:** `Photon.Realtime`<br>
**Signature:** `Extensions`

> This static class defines some useful extension methods for several existing classes (e.g. Vector3, float and others).

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `private` | keysWithNullValue | `List`1` | Used by StripKeysWithNullValues. |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S Merge | IDictionary target, IDictionary addHash | `Void` | Merges all keys from addHash into the target. Adds new keys and updates the values of existing keys in target. |
| `public` | S MergeStringKeys | IDictionary target, IDictionary addHash | `Void` | Merges keys of type string to target Hashtable. |
| `public` | S ToStringFull | IDictionary origin | `String` | Helper method for debugging of IDictionary content, including type-information. Using this is not performant.<br>Helper method for debugging of object[] content. Using this is not performant. |
| `public` | S ToStringFull | List`1 data | `String` | Helper method for debugging of IDictionary content, including type-information. Using this is not performant.<br>Helper method for debugging of object[] content. Using this is not performant. |
| `public` | S ToStringFull | Object[] data | `String` | Helper method for debugging of IDictionary content, including type-information. Using this is not performant.<br>Helper method for debugging of object[] content. Using this is not performant. |
| `public` | S StripToStringKeys | IDictionary original | `Hashtable` | This method copies all string-typed keys of the original into a new Hashtable. |
| `public` | S StripToStringKeys | Hashtable original | `Hashtable` | This method copies all string-typed keys of the original into a new Hashtable. |
| `public` | S StripKeysWithNullValues | IDictionary original | `Void` | Removes all keys with null values. |
| `public` | S StripKeysWithNullValues | Hashtable original | `Void` | Removes all keys with null values. |
| `public` | S Contains | Int32[] target, Int32 nr | `Boolean` | Checks if a particular integer value is in an int-array. |

---

