// 日本語対応
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ステージクリア時の演出を制御するクラスの基底クラス
/// </summary>
public abstract class StageCompleteEventBase : MonoBehaviour
{
    [Tooltip("ステージクリア時に実行するイベント"), SerializeField]
    private UnityEvent _onStageComplete = default;
    [Tooltip("ステージクリア演出が完了したときに実行するイベント"), SerializeField]
    private UnityEvent _onComplete = default;

    public UnityEvent OnStageComplete => _onStageComplete;
    public UnityEvent OnComplete => _onComplete;

    private void Awake()
    {
        // シーン起動時に自身を非アクティブにする。
        // シーン起動時にステージクリア時の演出は不要であるため。
        this.gameObject.SetActive(false);
    }
    private async void Start()
    {
        // ステージクリア時に実行するイベントを発行する
        _onStageComplete?.Invoke();
        // ゲームの状態を更新する
        GameManager.Instance.GameModeManager.ChangeGameMode(GameMode.Complete);
        // ステージクリア演出が完了するまで待機する
        await CompletePerformance();
        // 演出完了時処理を発行する
        _onComplete?.Invoke();
    }
    /// <summary>
    /// 継承先で独自のステージクリア演出を実装してください。
    /// </summary>
    protected abstract UniTask CompletePerformance();
}