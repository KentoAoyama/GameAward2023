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
        [SerializeField]
        private HowToPlayUI _howToPlayUI = default;

        public BulletSelectUIPresenter BulletSelectUIPresenter => _bulletSelectUIPresenter;

        private void Start()
        {
            _bulletSelectUIPresenter.Init(_playerController.InputManager, _playerController.BulletCountManager);
            _revolverUIPresenter.Init(_playerController);
            _howToPlayUI.Setup(_playerController.DeviceManager);
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
            _playerController.BulletCountManager.SetBullet(BulletType.StandardBullet, StringToInt(_standardBulletCountInputField.text));
            _playerController.BulletCountManager.SetBullet(BulletType.PenetrateBullet, StringToInt(_penetrateBulletCountInputField.text));
            _playerController.BulletCountManager.SetBullet(BulletType.ReflectBullet, StringToInt(_reflectBulletCountInputField.text));
        }
        public int StringToInt(string str) { return string.IsNullOrEmpty(str) ? 0 : int.Parse(str); }
    }
}
