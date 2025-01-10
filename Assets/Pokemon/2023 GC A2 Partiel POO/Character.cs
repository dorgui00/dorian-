using System;
using UnityEngine.UIElements;

namespace _2023_GC_A2_Partiel_POO.Level_2
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;

        int _currentHealth;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        Equipment _equipment;
        




        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            _currentHealth = _baseHealth;
            CurrentHealth = _currentHealth;

           



        }

        
        /// <summary>
        /// HP actuel du personnage
        /// </summary>


        public int CurrentHealth { get; private set ; }
        
        

        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                return _baseHealth;
            }
        }
        
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                return _baseAttack ;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                return _baseDefense ;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                return _baseSpeed ;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive;


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            if (CurrentHealth == 0) {
                IsAlive = false;
            }
            else
            {
                IsAlive = true;
                _currentHealth -= (s.Power - Defense);
            }
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment == null)
            {
                throw new ArgumentNullException();

            } else {
                _baseHealth += _equipment.BonusHealth;
                _baseAttack += _equipment.BonusAttack;
                _baseDefense += _equipment.BonusDefense;
                _baseSpeed += _equipment.BonusSpeed;
                CurrentEquipment = newEquipment;
            }
                
            
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            _baseHealth -= _equipment.BonusHealth;
            _baseAttack -= _equipment.BonusAttack;
            _baseDefense -= _equipment.BonusDefense;
            _baseSpeed -= _equipment.BonusSpeed;
            CurrentEquipment = null;
        }
    

    
    }
    
    }
