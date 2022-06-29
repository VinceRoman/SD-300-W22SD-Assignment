Game battleCatsReturn = new Game();

Console.WriteLine("Enter the name of your Swordsman Cat!");
string input = Console.ReadLine();

battleCatsReturn.Start(0,0,battleCatsReturn, input);

class Hero
{
    public string Name { get; set; }
    public int BaseStrength { get; set; }
    public int BaseDefence { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }
    public Weapon EquippedWeapon { get; set; }
    public Armor EquippedArmor { get; set; }

    public void ShowStats()
    {
        Console.WriteLine($"{Name}'s Stats\n" +
                          $"HP: {CurrentHealth}/{OriginalHealth}\n" +
                          $"STR:{BaseStrength} + {EquippedWeapon.Power}\n" +
                          $"DEF:{BaseDefence} + {EquippedArmor.Defence}");
    }
    public void ShowInventory()
    {
        Console.WriteLine($"{Name}'s Equipped armaments\n" +
                          $"WPN: [DMG:{EquippedWeapon.Power}] {EquippedWeapon.Name} \n" +
                          $"AMR: [DEF:{EquippedArmor.Defence}] {EquippedArmor.Name}  \n");
    }

    //sets the current equipped weapon to a new one
    public void EquipWeapon(Weapon inputWeapon)
    {
        Console.WriteLine($"{Name} equipped {inputWeapon.Name}!");
        EquippedWeapon = inputWeapon;
    }
    //sets the current equipped armor to a new one
    public void EquipArmor(Armor inputArmor)
    {
        Console.WriteLine($"{Name} equipped {inputArmor.Name}!");
        EquippedArmor = inputArmor;
    }

    //simply returns the weapon class that is currently being used by the player
    public Weapon getEquipWeapon()
    {
        return EquippedWeapon;
    }
    //simply returns the armor class that is currently being used by the player
    public Armor getEquipArmor()
    {
        return EquippedArmor;
    }
    /*
        Constructor that accepts all values needed for the hero.
        Only the name will be the input by the user, others are base values.
     */
    public Hero(string name, Weapon weapon, Armor armor)
    {
        Name = name;
        BaseStrength = 2;
        BaseDefence = 1;
        OriginalHealth = 100;
        CurrentHealth = 100;
        EquippedWeapon = weapon;
        EquippedArmor = armor;
    }
}

class Monster
{
    public string Name { get; set; }
    public int BaseStrength { get; set; }
    public int BaseDefence { get; set; }
    public int OriginalHealth { get; set; }
    public int CurrentHealth { get; set; }

    /*
        Constructor that accepts all values needed for the enemy.
        Will only be used by the developer to make hardcoded enemy types.
     */
    public Monster(string name, int baseStrength, int baseDefence, int originalHealth, int currentHealth)
    {
        Name = name;
        BaseStrength = baseStrength;
        BaseDefence = baseDefence;
        OriginalHealth = originalHealth;
        CurrentHealth = currentHealth;
    }
}

class Weapon
{
    public string Name { get; set; }
    public int Power { get; set; }
    /*
        Constructor to set hardcoded values for weapons.
     */
    public Weapon(string name, int power)
    {
        Name = name;
        Power = power;
    }
}

class Armor
{
    public string Name { get; set; }
    public int Defence { get; set; }
    /*
        Constructor to set hardcoded values for weapons.
     */
    public Armor(string name, int defence)
    {
        Name = name;
        Defence = defence;
    }
}

class WeaponList
{
    public List<Weapon> Weapons = new List<Weapon>();
    public int WeaponID { get; set; } = 0;
    public void addWeapon(Weapon inputWeapon)
    {
        Weapons.Add(inputWeapon);
        WeaponID++;
    }

    //returns a weapon to be used using a search input
    //searches via iterating through the array
    public Weapon getWeapon(string searchInput)
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            if (Weapons[i].Name.ToLower() == searchInput.ToLower())
            {
                Console.WriteLine(Weapons[i].Name + " Given");
                return Weapons[i];
            }
        }

        Console.WriteLine($"Weapon not found, now using: {Weapons[0]}");
        return Weapons[0];
    }
}

class ArmorList
{
    public List<Armor> Armors = new List<Armor>();
    public int ArmorID { get; set; } = 0;
    public void addArmor(Armor inputArmor)
    {
        Armors.Add(inputArmor);
        ArmorID++;
    }

    //returns an armor to be used using a search input
    //searches via iterating through the array
    public Armor getArmor(string searchInput)
    {
        for(int i = 0; i < Armors.Count; i++)
        {
            if (Armors[i].Name.ToLower() == searchInput.ToLower())
            {
                Console.WriteLine(Armors[i].Name + " Given");
                return Armors[i];
            }
        }

        Console.WriteLine($"Armor not found, now using: {Armors[0]}");
        return Armors[0];
    }
}

class MonsterList
{
    //public Dictionary<int, Monster> Monsters = new Dictionary<int, Monster>();

    public List<Monster> Monsters = new List<Monster>();
    public int MonsterID { get; set; } = 0;
    public void addMonster(Monster inputMonster)
    {
        Monsters.Add(inputMonster);
        MonsterID++;
    }

    public Monster getMonster()//returns a random monster from the list
    {
        Random rng = new Random();
        int index = rng.Next(Monsters.Count);
        return Monsters[index];
    }
}

class Game
{
    public int wins { get; set; }
    public int loses { get; set; }
    public void Start(int won, int lost, Game state, string name)
    {
        //set wins and losses
        wins += won;
        loses += lost;
        //initializing
        ArmorList armorlist = new ArmorList();
        MonsterList monsterlist = new MonsterList();
        WeaponList weaponlist = new WeaponList();

        //                                  name, damage
        Weapon swordsmanBlade = new Weapon("Swordsman's Blade", 10);
        Weapon swordsmanTwinBlade = new Weapon("Sword Master's Twin Blades", 15);
        Weapon swordsmanEpee = new Weapon("Duelist's Epee", 20);

        weaponlist.addWeapon(swordsmanBlade);
        weaponlist.addWeapon(swordsmanTwinBlade);
        weaponlist.addWeapon(swordsmanEpee);

        //                     name, defense
        Armor coat = new Armor("Coat", 2);
        Armor gambeson = new Armor("Gambeson", 4);
        Armor chainmail = new Armor("Chainmail", 10);

        armorlist.addArmor(coat);
        armorlist.addArmor(gambeson);
        armorlist.addArmor(chainmail);

        //                         name,dmg,def,maxhp,hp
        Monster doge = new Monster("Doge", 15, 0, 60, 60);
        Monster snek = new Monster("Snake", 25, 5, 35, 35);
        Monster stik = new Monster("The Guys", 20, 3, 80, 80);
        Monster bear = new Monster("A BEAR", 30, 0, 50, 50);
        Monster cate = new Monster("Crazed Cat",50,10,70,70);

        monsterlist.addMonster(doge);
        monsterlist.addMonster(snek);
        monsterlist.addMonster(stik);
        monsterlist.addMonster(bear);
        monsterlist.addMonster(cate);

        
        Hero player = new Hero(name,swordsmanBlade,coat);

        Menu(player, armorlist, monsterlist, weaponlist, state);//officially start, send needed info
    }

    public void Menu(Hero player, ArmorList armorlist, MonsterList monsterlist, WeaponList weaponlist, Game state)
    {
        Console.Clear();//this is to make the visuals easier to follow, it'll only display what is needed which is in focus, in this method, it is the menu stuff.
        bool menuActive = true;

        Console.WriteLine(player.Name + " Loaded...");
        player.ShowInventory();
        player.ShowStats();

        while (menuActive)
        {
            Console.WriteLine("---------------------------------------[Menu]");
            Console.WriteLine("A.) Battle statistics.");
            Console.WriteLine("B.) Inventory.");
            Console.WriteLine("C.) Fight!");
            Console.WriteLine("---------------------------------------[Type a letter to select]");

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "a":
                    Stats();
                    break;
                case "b"://pass everything through player, armorlist, monsterlist, weaponlist
                    Inventory(player, armorlist, monsterlist, weaponlist, state);
                    menuActive = false;//when moving to a different "screen" with selection options, use this. then the other "screen" should be the one active until it returns here.
                    break;
                case "c":
                    Fight battle = new Fight(player, monsterlist.getMonster(), state);//instantiate a new fight
                    battle.Begin();//start the fight
                    menuActive = false;//move screens
                    break;
                default://if it is none of those
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }
    }

    public void Stats()
    {
        Console.Clear();
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~[Statistics]");
        Console.WriteLine($"Victories: {wins}");
        Console.WriteLine($"Defeats:   {loses}");
    }

    public void Inventory(Hero player, ArmorList armorlist, MonsterList monsterlist, WeaponList weaponlist, Game state)//monsterlist and state is just here to get back to the menu
    {
        bool menuActive = true;
        bool wpnMenuAtv = false;//weapon menu active?
        bool armMenuAtv = false;//armor menu active?

        while (menuActive)
        {
            Console.Clear();
            Console.WriteLine("=======================================[Inventory]");
            Console.WriteLine($"Equipped Weapon: {player.EquippedWeapon.Name}");
            Console.WriteLine($"Equipped Armor:  {player.EquippedArmor.Name}");
            Console.WriteLine($"A.) Change Weapon.");
            Console.WriteLine($"B.) Change Armor.");
            Console.WriteLine($"C.) Back.");

            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "a"://goes to weapon select screen
                    wpnMenuAtv = true;//switching menus
                    menuActive = false;
                    while (wpnMenuAtv)
                    {
                        Console.Clear();
                        Console.WriteLine("=======================================[Weapon Equip?]");
                        Console.WriteLine($"A.) Swordsman's Blade-----------------[DMG: 10]");
                        Console.WriteLine($"B.) Sword Master's Twin Blades--------[DMG: 15]");
                        Console.WriteLine($"C.) Duelist's Epee--------------------[DMG: 20]");
                        Console.WriteLine($"D.) Back.");

                        
                        string inputw = Console.ReadLine().ToLower();

                        switch (inputw)
                        {
                            case "a":
                                player.EquipWeapon(weaponlist.getWeapon("Swordsman's Blade"));

                                menuActive = true;
                                wpnMenuAtv = false;
                                break;
                            case "b":
                                player.EquipWeapon(weaponlist.getWeapon("Sword Master's Twin Blades"));

                                menuActive = true;
                                wpnMenuAtv = false;
                                break;
                            case "c":
                                player.EquipWeapon(weaponlist.getWeapon("Duelist's Epee"));

                                menuActive = true;
                                wpnMenuAtv = false;
                                break;
                            case "d"://back to inventory screen without changes
                                menuActive = true;
                                wpnMenuAtv = false;
                                break;
                            default://if it is none of those
                                Console.WriteLine("Invalid selection.");
                                break;
                        }
                    }

                    break;
                case "b":
                    armMenuAtv = true;//switching menus
                    menuActive = false;
                    while (armMenuAtv)
                    {
                        Console.Clear();
                        Console.WriteLine("=======================================[Armor Equip?]");
                        Console.WriteLine($"A.) Coat------------------------------[DEF: 2]");
                        Console.WriteLine($"B.) Gambeson--------------------------[DEF: 4]");
                        Console.WriteLine($"C.) Chainmail-------------------------[DEF: 10]");
                        Console.WriteLine($"D.) Back.");


                        string inputw = Console.ReadLine().ToLower();

                        switch (inputw)
                        {
                            case "a":
                                player.EquipArmor(armorlist.getArmor("Coat"));

                                menuActive = true;
                                armMenuAtv = false;
                                break;
                            case "b"://pass everything through player, armorlist, monsterlist, weaponlist
                                player.EquipArmor(armorlist.getArmor("Gambeson"));

                                menuActive = true;
                                armMenuAtv = false;
                                break;
                            case "c":
                                player.EquipArmor(armorlist.getArmor("Chainmail"));

                                menuActive = true;
                                armMenuAtv = false;
                                break;
                            case "d"://back to inventory screen without changes
                                menuActive = true;
                                armMenuAtv = false;
                                break;
                            default://if it is none of those
                                Console.WriteLine("Invalid selection.");
                                break;
                        }
                    }
                    break;
                case "c":
                    Menu(player, armorlist, monsterlist, weaponlist, state);
                    menuActive = false;
                    break;
                default://if it is none of those
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }
        
    }
}


class Fight
{
    public Hero Player { get; set; }
    public Monster Monster { get; set; }
    public Game game { get; set; }
    public bool isFighting { get; set; } = true;
    public void Begin()//Purely aesthetic screen to show what you're up against and see the stats you brought with you in battle before it really begins.
    {
        Console.Clear();
        Console.WriteLine($"Battle begin!");
        Console.WriteLine($"{Player.Name} VS {Monster.Name}\n" +
                          $"HP : {Player.OriginalHealth} - {Monster.OriginalHealth}\n" +
                          $"DEF: {Player.EquippedArmor.Defence} - {Monster.BaseDefence}\n" +
                          $"ATK: {Player.EquippedWeapon.Power} - {Monster.BaseStrength}");
        Console.WriteLine("Loading battle...");
        Task.Delay(7000).Wait();//let this screen show up for a set amount of milliseconds
        HeroTurn();
    }
    public void HeroTurn()//Displays visual battle UI to give the game some flavor even though you don't get a choice of attacks.
    {//                     also calculates hp reduction
        Console.Clear();
        Console.WriteLine($"{Player.Name} strikes with {Player.EquippedWeapon.Name} at {Monster.Name} for {Player.EquippedWeapon.Power} damage!");

        //subtract weapon's power with the opponent's defence before subtracting hp.
        Monster.CurrentHealth -= ((Player.BaseStrength + Player.EquippedWeapon.Power) - Monster.BaseDefence);
        
        DisplayBattleHP();
        Task.Delay(2000).Wait();

        Win();//since this is about subtracting a monster's hp, and win checks if monster has <= 0 hp. Lose() is vice versa
        if (isFighting)//checks if the battle has been won or not yet. Determined by Win() or Lose();
        {
            MonsterTurn();//Monster gets to attack
        }
    }
    public void MonsterTurn()
    {
        Console.Clear();
        Console.WriteLine($"{Monster.Name} attacks {Player.Name} for {Monster.BaseStrength} damage!");

        Player.CurrentHealth -= (Monster.BaseStrength - (Player.BaseDefence - Player.EquippedArmor.Defence));
        
        DisplayBattleHP();
        Task.Delay(2000).Wait();

        Lose();
        if (isFighting)
        {
            HeroTurn();//Hero gets to attack
        }
    }

    public void Win()//check if monster hp is less than or equal to 0. Adds a win back at the game class. Returns to game start menu.
    {
        if(Monster.CurrentHealth <= 0)
        {
            for(int i = 10; i > 0; i--)//small animation
            {
                if((i % 2) == 0)
                {
                    Console.Clear();
                    Console.WriteLine("oOoOoOoOoOoOoOoOoOoOoOoO");
                    Console.WriteLine($"{Player.Name} has won the battle!");
                    Console.WriteLine("OoOoOoOoOoOoOoOoOoOoOoOo");

                    Task.Delay(500).Wait();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("OoOoOoOoOoOoOoOoOoOoOoOo");
                    Console.WriteLine($"{Player.Name} has won the battle!");
                    Console.WriteLine("oOoOoOoOoOoOoOoOoOoOoOoO");

                    Task.Delay(500).Wait();
                }
            }
            //        won,lost
            game.Start(1,0,game,Player.Name);
            isFighting = false;
        }
    }

    public void Lose()//check if player hp is less than or equal to 0. Adds a loss back at the game class. Returns to game start menu.
    {
        if (Player.CurrentHealth <= 0)
        {
            for (int i = 10; i > 0; i--)//small animation
            {
                if ((i % 2) == 0)
                {
                    Console.Clear();
                    Console.WriteLine("xXxXxXxXxXxXxXxXxXxXxXxX");
                    Console.WriteLine($"{Player.Name} has lost the battle...");
                    Console.WriteLine("XxXxXxXxXxXxXxXxXxXxXxXx");

                    Task.Delay(500).Wait();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("XxXxXxXxXxXxXxXxXxXxXxXx");
                    Console.WriteLine($"{Player.Name} has lost the battle...");
                    Console.WriteLine("xXxXxXxXxXxXxXxXxXxXxXxX");

                    Task.Delay(500).Wait();
                }
            }

            //        won,lost
            game.Start(0, 1, game, Player.Name);
            isFighting = false;
        }
    }

    public void DisplayBattleHP()//displays the player and monsters HP values:   current/total, helps with battle UI so it is easier to track the fight progression.
    {
        Console.WriteLine("<X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X+X>");
        Console.WriteLine($"MONSTER HP: {Monster.CurrentHealth}/{Monster.OriginalHealth}");
        Console.WriteLine($"PLAYER  HP: {Player.CurrentHealth}/{Player.OriginalHealth}");
    }

    public Fight(Hero player, Monster monster, Game game)//constructor to set the battlefield
    {
        Player = player;
        Monster = monster;
        this.game = game;
    }
}