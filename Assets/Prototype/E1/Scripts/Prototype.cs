using System;
using System.Collections;
using System.Collections.Generic;
using AnimalBase;
using EnemyBase;
using SpawnBase;
using UnityEngine;

public class Prototype : MonoBehaviour
{
    private AnimalBase.Sheep _animal_sheep;
    private EnemyBase.Ghost _enemy_ghost;
    private readonly KeyCode _keyCodeInput;
    
    private void Start()
    {
        _animal_sheep = new Sheep(100,10);
        _enemy_ghost = new Ghost(100,10);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            AnimalSpawner _sheepSpawner = new AnimalSpawner(_animal_sheep);
            
            Sheep newSheep = _sheepSpawner.AnimalSpawnTime() as Sheep;
            
            newSheep.Instruction();
            
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            EnemySpawner _ghostSpawner = new EnemySpawner(_enemy_ghost);
            
            Ghost newGhost = _ghostSpawner.EnemySpawnTime() as Ghost;
            
            newGhost.Instruction();
    
        } 
    }
}

namespace AnimalBase
{

    public abstract class Animal
    {
        public abstract Animal Clone();

        public abstract void Instruction();
    }

    public class Sheep : Animal
    {
        private readonly double _health;
        private readonly double _protection;

        public Sheep(double health, double protection)
        {
            this._health = health;
            this._protection = protection;
        }
            
        public override Animal Clone()
        {
            return new Sheep(_health,_protection);
        }
        public override void Instruction()
        {
            Debug.Log("Sheep: Message!");
        }
    }    
}

namespace EnemyBase
{
    public abstract class Enemy
    {
        public abstract Enemy Clone();
        public abstract void Instruction();
    }

    public class Ghost : Enemy
    {
        private readonly double _AttackPower;
        private readonly double _Health;

        public Ghost(double attackPower, double health)
        {
            this._Health = health;
            this._AttackPower = attackPower;
        }

        public override void Instruction()
        {
            Debug.Log("Hi! U re gonna be die!");
        }

        public override Enemy Clone()
        {
            return new Ghost(_AttackPower, _Health);
        }
    }
}
namespace SpawnBase
{
    public class AnimalSpawner
    {
        private AnimalBase.Animal _animal;

        public AnimalSpawner(AnimalBase.Animal animal)
        {
            this._animal = animal;
        }

        public AnimalBase.Animal AnimalSpawnTime()
        {
            return _animal.Clone();
        }
    }

    public class EnemySpawner
    {
        private EnemyBase.Enemy _enemy;

        public EnemySpawner(EnemyBase.Enemy animal)
        {
            this._enemy = animal;
        }

        public EnemyBase.Enemy EnemySpawnTime()
        {
            return _enemy.Clone();
        }
    }

}