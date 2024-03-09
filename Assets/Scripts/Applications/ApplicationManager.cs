using OskaKim.Applications.GameScene;
using UnityEngine;

namespace OskaKim.Applications
{
    public class ApplicationManager : MonoBehaviour
    {
        [SerializeField] private RootLifetimeScope rootLifetimeScope;
        [SerializeField] private MonoBehaviour startGameScene;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            if (startGameScene is IGameScene gameScene)
                gameScene.Initialize(rootLifetimeScope);
        }
    }
}
