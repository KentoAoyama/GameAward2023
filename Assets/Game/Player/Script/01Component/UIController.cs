using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.UI;
using Bullet;

namespace UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField]
        private PlayerController _playerController = default;
        [SerializeField]
        private BulletSelectUIPresenter _bulletSelectUIPresenter = default;
        [SerializeField]
        private RevolverUIPresenter _revolverUIPresenter = default;

        public BulletSelectUIPresenter BulletSelectUIPresenter => _bulletSelectUIPresenter;

        private void Start()
        {
            _bulletSelectUIPresenter.Init(_playerController.InputManager, _playerController.BulletsManager);
            _revolverUIPresenter.Init(_playerController);
        }
        private void Update()
        {
            _bulletSelectUIPresenter.Update();
        }

        [Header("�e�X�g�p")]
        [SerializeField]
        private InputField _standardBulletCountInputField = default;
        [SerializeField]
        private InputField _penetrateBulletCountInputField = default;
        [SerializeField]
        private InputField _reflectBulletCountInputField = default;
        /// <summary>
        /// �{�^������Ăяo���z��ō쐬�������\�b�h�B
        /// �C���v�b�g�t�B�[���h�ɓ��͂��ꂽ�l���������Ɋ��蓖�Ă�B
        /// </summary>
        public void AssignInputFieldValues()
        {
            _playerController.BulletsManager.SetBullet(BulletType.StandardBullet, StringToInt(_standardBulletCountInputField.text));
            _playerController.BulletsManager.SetBullet(BulletType.PenetrateBullet, StringToInt(_penetrateBulletCountInputField.text));
            _playerController.BulletsManager.SetBullet(BulletType.ReflectBullet, StringToInt(_reflectBulletCountInputField.text));
        }
        public int StringToInt(string str) { return string.IsNullOrEmpty(str) ? 0 : int.Parse(str); }
    }
}
