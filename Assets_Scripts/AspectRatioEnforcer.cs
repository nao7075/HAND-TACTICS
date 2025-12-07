using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 画面のアスペクト比を強制的に固定するクラス。
/// ウィンドウサイズが変更された場合、指定したアスペクト比（targetAspect）を維持するように
/// 解像度（幅または高さ）を自動的に調整します。
/// </summary>
public class AspectRatioEnforcer : MonoBehaviour
{
    // 1. 維持したいアスペクト比 (例: 16:9 = 1.777...)
    // この値を基準に画面サイズが調整されます。
    public float targetAspect = 16.0f / 9.0f;// 1. 維持したいアスペクト比 (例: 16:9 = 1.777...)

    // 2. 前のフレームのウィンドウサイズを記憶する変数
    // サイズ変更があったかどうかを検知するために使用します。
    private int lastWidth = 0;// 前のフレームのウィンドウサイズを記憶する変数
    private int lastHeight = 0;// 前のフレームのウィンドウサイズを記憶する変数

    void Start()
    {
        // ゲーム開始時の画面サイズを初期値として記憶
        lastWidth = Screen.width;
        lastHeight = Screen.height;
    }

    void Update()
    {
        // 現在のフレームでの画面サイズを取得
        int currentWidth = Screen.width;
        int currentHeight = Screen.height;

        // 3. サイズが変更されていないか、フルスクリーンモードなら何もしない
        // フルスクリーンモードでは解像度変更の挙動がOS依存になるため、処理をスキップします。
        // ウィンドウモードでのリサイズ時のみ動作させる意図があります。
        if ((currentWidth == lastWidth && currentHeight == lastHeight) || Screen.fullScreen)
        {
            return;
        }

        // 4. 現在のアスペクト比を計算
        float currentAspect = (float)currentWidth / currentHeight;

        // 許容誤差 (ほぼ同じアスペクト比なら補正しない)
        // 浮動小数点の計算誤差を考慮し、わずかな違いなら無視します。
        float tolerance = 0.01f; 
        if (Mathf.Abs(currentAspect - targetAspect) < tolerance)
        {
            // アスペクト比が合っているので、現在のサイズを「正しいサイズ」として記憶して終了
            lastWidth = currentWidth;
            lastHeight = currentHeight;
            return;
        }

        // --- ここからアスペクト比の補正 ---
        // ユーザーがウィンドウの端をドラッグしてサイズを変えたと仮定し、
        // アスペクト比を保つように対辺の長さを強制的に変更します。

        // 5. ユーザーが「幅」を変更したと仮定する
        // (幅が変わった場合、それに合わせて高さを調整)
        if (currentWidth != lastWidth) 
        {
            // ターゲットのアスペクト比になるように「高さ」を計算
            // 高さ = 幅 / アスペクト比
            int newHeight = Mathf.RoundToInt(currentWidth / targetAspect);
            
            // 計算した新しい高さで解像度を設定 (ウィンドウモードを維持)
            Screen.SetResolution(currentWidth, newHeight, false); 
        }
        // 6. ユーザーが「高さ」を変更したと仮定する
        // (高さが変わった場合、それに合わせて幅を調整)
        else if (currentHeight != lastHeight)
        {
            // ターゲットのアスペクト比になるように「幅」を計算
            // 幅 = 高さ * アスペクト比
            int newWidth = Mathf.RoundToInt(currentHeight * targetAspect);
            
            // 計算した新しい幅で解像度を設定 (ウィンドウモードを維持)
            Screen.SetResolution(newWidth, currentHeight, false);
        }

        // 7. 補正後の解像度を次フレームの比較用に記憶
        // これにより、SetResolutionによる変更が次のフレームで「ユーザーによる変更」と誤検知されるのを防ぎます。
        lastWidth = Screen.width;
        lastHeight = Screen.height;
    }
}