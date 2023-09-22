using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Codebase
{
    public class LoadScreen : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private int _duration = 5;

        private async void Start()
        {
            _image.fillAmount = 0;
            int random = Random.Range(-3, 3);
            var fillTween = _image.DOFillAmount(1, _duration + random);

            await UniTask.Delay(_duration * 1000, true)
                         .ContinueWith(() => fillTween?.Kill())
                         .ContinueWith(() => SceneManager.LoadScene(1));
        }
    }
}