using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatformController : MonoBehaviour
{
    //Позиция, от которой будет строиться вся змейка.
    [SerializeField]
    private Vector3 firstPlatformPosition;
    //В этой переменной храним позицию последней созданной платформы.
    private Vector3 platformPosition;

    //Размер списка для сощдаваемых платформ.
    [SerializeField]
    private int ListSize;

    [Inject]
    PlatformBehaviour.Factory factoryPlatform;
    [Inject]
    CapsuleBehaviour.Factory factoryCapsule;

    //Список для экземпляров платформ и капсул.
    public List<GameObject> PooledObjectsPlatform;
    public List<GameObject> PooledObjectsCapsule;

    private void Awake()
    {
        //Заполняем список платформ.
        for (int i = 0; i < ListSize; i++)
        {
            //Создаем нужный объект.
            var obj = factoryPlatform.Create();
            //Делаем объект не активным.
            obj.gameObject.SetActive(false);
            //Добавляем объект в список.
            PooledObjectsPlatform.Add(obj.gameObject);
        }

        //Заполняем список капсул.
        for (int i = 0; i < ListSize; i++)
        {
            var obj = factoryCapsule.Create();
            obj.gameObject.SetActive(false);
            PooledObjectsCapsule.Add(obj.gameObject);
        }
    }

    //Создание змайки из платформ перед запуском уровня.
    public void Initialize()
    { 
        //Первая платформа всегда находиться "Вверху".
        ObjCreate(PooledObjectsPlatform, firstPlatformPosition);
        platformPosition = firstPlatformPosition;

        for (int i = 0; i < ListSize - 1; i++)
        {
            //В зависимости от рандома выставляем платформу выше или левее текущей платформы.
            if (Random.Range(0, 2) == 0)
            {
                //Устанавливаем новые координаты для платформы.
                platformPosition += new Vector3(1, 0, 0);
                //Создаем платформу.
                ObjCreate(PooledObjectsPlatform, platformPosition);
                //В зависимости от рандома, создаем над платформой капсулу.
                if (Random.Range(1, 101) <= 20)
                {
                    ObjCreate(PooledObjectsCapsule, platformPosition + new Vector3(0, 0.4f, 0));
                }
            }
            else
            {
                platformPosition += new Vector3(0, 0, 1);
                ObjCreate(PooledObjectsPlatform, platformPosition);
                if (Random.Range(1, 101) <= 20)
                {
                    ObjCreate(PooledObjectsCapsule, platformPosition + new Vector3(0, 0.4f, 0));
                }
            }
        }   
    }

    //Метод для вытаскивания свободного объекта из списка и переноса его на нужные координаты.
    public void ObjCreate(List<GameObject> gameObjects, Vector3 position)
    { 
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (!gameObjects[i].activeSelf)
            {
                gameObjects[i].transform.position = position;
                gameObjects[i].SetActive(true);
                break;
            }  
        }   
    }

    //Метод делает все элементы списка не активными,
    //его нужно вызывать после проигрыша игрока,
    public void DiactivateAllObj()
    {
        for (int i = 0; i < PooledObjectsPlatform.Count; i++)
        {
            PooledObjectsPlatform[i].SetActive(false);
        }

        for (int i = 0; i < PooledObjectsCapsule.Count; i++)
        {
            PooledObjectsCapsule[i].SetActive(false);
        }

    }

    //Метод для перемещения платформы на новое положение
    //его нужно вызвать, когда платформа пройдена игроком 
    //и анимация падения закончилась.
    public void SetNewPositionObj(GameObject platformObj)
    {
        if (Random.Range(0, 2) == 0)
        {
            platformPosition += new Vector3(1, 0, 0);
            platformObj.transform.position = platformPosition;
            if (Random.Range(1, 101) <= 20)
            {
                ObjCreate(PooledObjectsCapsule, platformPosition + new Vector3(0, 0.4f, 0));
            }    
        }
        else
        {
            platformPosition += new Vector3(0, 0, 1);
            platformObj.transform.position = platformPosition;
            if (Random.Range(1, 101) <= 20)
            {
                ObjCreate(PooledObjectsCapsule, platformPosition + new Vector3(0, 0.4f, 0));
            }   
        }
    }
}
