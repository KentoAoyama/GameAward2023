// 日本語対応
using System;
using UnityEngine;
using Input;

namespace Player
{
    public class InputManager : InputManagerBase<GameController, InputType>
    {
        protected override void Setup()
        {
            SetAction<float>(_inputActionCollection.Player.Horizontal, InputType.MoveHorizontal);
            SetAction<float>(_inputActionCollection.Player.Vertical, InputType.InputVertical);
            SetAction<float>(_inputActionCollection.Player.Jump, InputType.Jump);
            SetAction<Vector2>(_inputActionCollection.Player.LookingAngle, InputType.LookingAngle);
            SetAction<float>(_inputActionCollection.Player.Fire1, InputType.Fire1);
            SetAction<float>(_inputActionCollection.Player.Avoidance, InputType.Avoidance);
            SetAction<float>(_inputActionCollection.Player.CrossButtonHorizontal, InputType.HorizontalSelect);
            SetAction<float>(_inputActionCollection.Player.LoadBullet, InputType.LoadBullet);
        }
    }
    public enum InputType
    {
        /// <summary> 移動用 横入力 </summary>
        MoveHorizontal,
        /// <summary> 縦入力 </summary>
        InputVertical,
        /// <summary> ジャンプ入力 </summary>
        Jump,
        /// <summary> プレイヤーが向いているベクトルを表す </summary>
        LookingAngle,
        /// <summary> 攻撃ボタン </summary>
        Fire1,
        /// <summary> 回避ボタン </summary>
        Avoidance,
        /// <summary> 選択用 横入力 </summary>
        HorizontalSelect,
        /// <summary> リロード入力 </summary>
        LoadBullet,
    }
}