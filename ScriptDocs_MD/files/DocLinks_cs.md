# File: DocLinks.cs
[< トップページへ戻る](../Index.md)

> **Path:** `Assets/Photon/PhotonUnityNetworking/Demos/Shared Assets/Scripts/DocLinks.cs`

<a id='DocLinks'></a>
## Class DocLinks
**Namespace:** `Photon.Pun.Demo.Shared`<br>
**Signature:** `DocLinks`

> Document links.

### フィールド (Variables)
| アクセス | 名前 | 型 | 説明 | 属性・制約 |
| :---: | :--- | :---: | :--- | :---: |
| `public` | Version | `Versions` | The version to generate links for |  |
| `public` | Language | `Languages` | The language to generate links with |  |
| `public` | Product | `Products` | The product to generate links for |  |
| `public` | ApiUrlRoot | `String` | The API URL format.<br>0 is the Language<br>1 is the Product<br>2 is the Version<br>3 is the custom part passed to generate the link with<br>doc-api.photonengine.com/{0}/{1}/{2}/{3}"; |  |
| `public` | DocUrlFormat | `String` | The API URL format.<br>0 is the Language<br>1 is the Product<br>2 is the Version<br>3 is the custom part passed to generate the link with<br>doc.photonengine.com/{0}/{1}/{2}/{3}"; |  |
| `private` | ProductsFolders | `Dictionary`2` | The API URL format.<br>0 is the Language<br>1 is the Product<br>2 is the Version<br>3 is the custom part passed to generate the link with |  |
| `private` | ApiLanguagesFolder | `Dictionary`2` | The API URL format.<br>0 is the Language<br>1 is the Product<br>2 is the Version<br>3 is the custom part passed to generate the link with |  |
| `private` | DocLanguagesFolder | `Dictionary`2` | The API URL format.<br>0 is the Language<br>1 is the Product<br>2 is the Version<br>3 is the custom part passed to generate the link with |  |
| `private` | VersionsFolder | `Dictionary`2` | The API URL format.<br>0 is the Language<br>1 is the Product<br>2 is the Version<br>3 is the custom part passed to generate the link with |  |

### メソッド (Methods)
| アクセス | 名前 | 引数 | 戻り値 | 説明 |
| :---: | :--- | :--- | :---: | :--- |
| `public` | S GetLink | DocTypes type, String reference | `String` | The API URL format.<br>0 is the Language<br>1 is the Product<br>2 is the Version<br>3 is the custom part passed to generate the link with |
| `public` | S GetApiLink | String reference | `String` | Gets the API link given a reference |
| `public` | S GetDocLink | String reference | `String` | Gets the Doc link given a reference |

---

