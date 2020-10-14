package main

import (
	"bufio"
	"fmt"
	"math/rand"
	"os"
	"strconv"
	"strings"
	"time"
)

type unit struct {
	Name       string
	MaxHealth  int
	Health     int
	Attack     int
	Defense    int
	Experience int
	wepBonus   int
	armBonus   int
}

var (
	attackAdjective   = []string{"lunges", "dives", "strikes", "charges", "cuts", "slashes", "jabs", "stabs", "swipes"}
	weaponAdjective   = []string{"Normal", "Flaming", "Ice", "", "Burning", "Iron", "Shadow", "Freezing", "Lit", "Wooden", "Steel", "Stone", "Sharp", "Blunt", "Curved", "Pointy", "Sticky"}
	weaponType        = []string{"Sword", "Long Sword", "Short Sword", "Whip", "Hammer", "Dagger", "Scimitar", "Halberd", "Dual Daggers", "Dual Swords", "Warhammer", "Battle Axe", "Spear", "Staff"}
	weaponOrigin      = []string{"Borington", "The Shire", "Isengard", "Rohan", "The Windmills of Rotterdam", "Oakland", "The Shadow Realm", "The Abyss", "Mom's Kitchen", "Light", "Forging", "Gandalf"}
	WeakMonsterName   = []string{"Goblin", "Kobold", "Giant Rat", "Spider", "Zombie Dog", "Drunk Man", "Drunk Woman", "Rabid Dog", "Giant Bat"}
	NormMonsterName   = []string{"Zombie", "Devil Dog", "Mutant", "Giant Spider", "Giant Scorpion", "Hobgoblin", "Orc", "Greater Goblin", "Centaur", "Minotuar", "Lesser Demon", "Flesh Crawler", "Beast", "Skeleton"}
	StrongMonsterName = []string{"Baby Dragon", "Demon", "Giant Snake", "Mutant Ninja Turtle", "Aviansie", "Shadow Assassin", "Dark Lord", "Orc Chieftain", "Battle Mage", "Corrupted Bear", "Hydra"}
	//ExtremeMonsterName = []string{"Basilisk","Giant Hydra","Cyclops","Giant","Archer Squad","Red Dragon","Black Dragon","Greater Demon","Mark Zuckerberg","Djinn","Genie","Undead Army","Chimera","Sphinx"}
	Places       = []string{"tavern", "city center", "town square", "old barn", "bar", "local shop", "blacksmith", "archery store", "fighter's guild", "wizard's tower", "witch's hut", "bridge", "city gates", "nearby lake"}
	Characters   = []string{"the Old Farmer", "the Farmer", "John of Buckenshire", "the shopkeeper", "your mom", "the king", "the king's guard", "a hermit", "the magician", "the wizard", "Frodo", "Ash Ketchum", "Bob which Buildeth", "Crazy James"}
	Descriptions = []string{"You meander your way along a river.",
		"You climb up a rocky slope",
		"You brave the icy mountains of Galoran",
		"You find yourself in the middle of a very thick forest",
		"After finally lifting your leg over the final ledge of the mountain you climbed, you stand up and see that there are boulders at the top of the mountain",
		"You swim across the river Sungai",
		"You slice your way through the jungles of Brunei",
		"You find yourself in an abandoned ancient temple imbued with magic",
		"you climb down into the giant crater",
		"You have a wizard cast a teleportation spell on you",
		"You climb to the bottom of the Ravine of Decay",
		"You pass through the shadow thief encampment",
		"You get sucked into a whirpool and spat out onto a beach next to the Great Forest of the Gods",
		"You go to the end of a dark cave and out into the light",
		"You get dropped off by a giant bird"}
)

func input() string { // make input easy
	scanner := bufio.NewScanner(os.Stdin)
	scanner.Scan()
	fmt.Println(scanner.Text())
	return (scanner.Text())
}

func get_level(player unit) int {
	return (player.MaxHealth/5 + player.Attack + player.Defense)
}

func random(number int) int {
	rand.Seed(time.Now().UTC().Unix())
	return rand.Intn(number)
}

func damage(attacker unit, defender unit) int {
	damage := random(attacker.Attack + 1)
	if damage != 0 && damage > defender.Defense {
		return damage - defender.Defense

	} else if damage == 0 {
		return 0
	} else {
		return 1
	}
}

func battle(player unit, monster *unit) int {
	fmt.Println("A " + monster.Name + " was hiding in the bushes! Prepare for battle!\n")

	time.Sleep(1 * time.Second)

	for player.Health > 0 && monster.Health > 0 {
		dmg1 := damage(player, *monster)
		fmt.Println(player.Name + " " + attackAdjective[random(len(attackAdjective))] + " forward dealing " + strconv.Itoa(dmg1) + " damage!")
		time.Sleep(1 * time.Second)
		dmg2 := damage(*monster, player)
		fmt.Println(monster.Name + " " + attackAdjective[random(len(attackAdjective))] + " forward dealing " + strconv.Itoa(dmg2) + " damage!")
		time.Sleep(1 * time.Second)
		monster.Health -= dmg1
		player.Health -= dmg2
	}
	return player.Health
}

func reward(player unit) int {
	bonus := random(get_level(player)/6 + 2)
	if random(10) > 1 { //Get a drop
		fmt.Println("\nThe monster dropped a " + weaponAdjective[random(len(weaponAdjective))] + " " + weaponType[random(len(weaponType))] + " of " + weaponOrigin[random(len(weaponOrigin))] + "!")
		fmt.Println("It gives an attack bonus of " + strconv.Itoa(bonus))
		fmt.Println("\nWould you like to replace it with your weapon that gives an attack bonus of " + strconv.Itoa(player.wepBonus) + "?")
		fmt.Println("\n\n 1 - Yes\n 2 - No")

		for {
			switch input() {
			case "1": // replace
				return bonus
			case "2": // dont replace
				return -1
			default:
				fmt.Println("Invalid input. Try again.")
			}
		}

	}
	return -1
}

func main() {

	player := unit{
		Name:       "",
		MaxHealth:  10,
		Health:     10,
		Attack:     1,
		Defense:    1,
		Experience: 0,
		wepBonus:   0,
		armBonus:   0,
	}

	//options: Venture, Stats, Rest, Save
	fmt.Println("\n\nWelcome to ScrubVenture!\n")
	fmt.Println("What is your name?")
	fmt.Print("Name: ")
	player.Name = input()

	file, err := os.Open(player.Name)
	if err != nil {
		fmt.Println("\nFile not found. Creating new character!")
	} else { // load profile
		fmt.Println("Character found! Loading character...")
		scanner := bufio.NewScanner(file)
		scanner.Scan()
		fmt.Println(scanner.Text())
		stats := strings.Split(scanner.Text(), ",")
		player.MaxHealth, err = strconv.Atoi(stats[1])
		player.Health, err = strconv.Atoi(stats[2])
		player.Attack, err = strconv.Atoi(stats[3])
		player.Defense, err = strconv.Atoi(stats[4])
		player.Experience, err = strconv.Atoi(stats[5])
		player.wepBonus, err = strconv.Atoi(stats[6])
		player.armBonus, err = strconv.Atoi(stats[7])
	}
	defer file.Close()

	for {
		// level up
		if player.Experience >= 100 {
			var levels int = player.Experience / 100
			player.Experience -= levels * 100 // subtracts however many levels they got from their experience
			fmt.Println("You have leveled up " + strconv.Itoa(levels) + " time(s)!")
			fmt.Println("Which stat do you want to use all of your levels on?")
			fmt.Println(" 1 - Attack\n 2 - Defense\n 3 - Health")
			done := false

			for done != true {
				switch input() {
				case "1":
					player.Attack += levels
					done = true
				case "2":
					player.Defense += levels
					done = true
				case "3":
					player.Health += levels * 3
					player.MaxHealth += levels * 3
					done = true
				default:
					fmt.Println("Invalid input.\n")
				}
			}
		}
		// Main Menu
		fmt.Println("What would you like to do?\n")
		fmt.Println(" 1 - Venture\n 2 - View Stats\n 3 - Rest\n 4 - Quest\n 5 - Save\n")
		fmt.Print(" -> ")

		switch input() {
		case "1":
			fmt.Println("\nYou venture off into the woods.")
			time.Sleep(1 * time.Second)
			fmt.Println("You hear something in the bushes and go to investigate it.")
			time.Sleep(1 * time.Second)
			monster := new(unit)
			if get_level(player) < 10 { // Beginner encounter until level >= 10
				monster.Name = "Practice Dummy"
				monster.Health = 3
				monster.Attack = 1
				monster.Experience = 51
			} else if get_level(player) >= 10 && get_level(player) < 25 { // Easy Encounter
				monster.Name = WeakMonsterName[random(len(WeakMonsterName))]
				monster.Health = random(5) + 10
				monster.Attack = random(4) + 1
				monster.Defense = random(3)
				monster.Experience = random(50) + 15
			} else if get_level(player) >= 25 && get_level(player) < 80 { // Normal Encounter
				monster.Name = NormMonsterName[random(len(NormMonsterName))]
				monster.Health = random(20) + 20
				monster.Attack = random(20) + 8
				monster.Defense = random(10)
				monster.Experience = random(175) + 79
			} else if get_level(player) >= 80 && get_level(player) < 200 { // Hard Encounter
				monster.Name = StrongMonsterName[random(len(StrongMonsterName))]
				monster.Health = random(player.Attack*4) + 30
				monster.Attack = random(player.Defense*2) + 16
				monster.Defense = random(get_level(player)/15 + 4)
				monster.Experience = random(325) + 105
			}

			player.Health = battle(player, monster)

			if player.Health > 0 { // If player survives the battle
				fmt.Println("\nYou've defeated the " + monster.Name + "!")
				fmt.Println("Health: " + strconv.Itoa(player.Health) + "/" + strconv.Itoa(player.MaxHealth))
				player.Experience += monster.Experience
				result := reward(player)
				if result != -1 {
					fmt.Println("You trash your weapon and pick up the new one.")
					player.Attack -= player.wepBonus
					player.Attack += result
					player.wepBonus = result
					time.Sleep(1 * time.Second)
				}
			} else { // DEAD
				fmt.Println("You died. Respawning.")
			}

		case "2":
			fmt.Println("\n    Stats for: " + player.Name)
			fmt.Println("    Health: " + strconv.Itoa(player.Health) + "/" + strconv.Itoa(player.MaxHealth))
			fmt.Println("    Attack: " + strconv.Itoa(player.Attack))
			fmt.Println("    Defense:" + strconv.Itoa(player.Defense))
			fmt.Println("    Weapon Attack: " + strconv.Itoa(player.wepBonus))
			fmt.Println("    Armor Defense: " + strconv.Itoa(player.armBonus))
			fmt.Println("    Experience: " + strconv.Itoa(player.Experience))
			fmt.Println("\n")
			time.Sleep(3 * time.Second)
		case "3":
			fmt.Println("\nYou set up camp for the night.")
			time.Sleep(2 * time.Second)
			player.Health = player.MaxHealth
			fmt.Println("You wake up feeling a lot better\n\n Health: " + strconv.Itoa(player.Health) + "/" + strconv.Itoa(player.MaxHealth) + "\n")
			time.Sleep(1 * time.Second)
		case "4":
			battles := random(5) + 1
			person := Characters[random(len(Characters))]
			place := Places[random(len(Places))]
			gains := 0 //Experience gained
			fmt.Println("\nYou decide to embark on a quest...\n")
			fmt.Println("You wander around, and end up at " + place + ".")
			time.Sleep(2 * time.Second)
			fmt.Println("As you spend time talking to the people around there, you bump into " + person)
			time.Sleep(3 * time.Second)
			fmt.Println(person + " says that there are " + strconv.Itoa(battles) + " monsters out yonder, so you go to vanquish all of them for some extra experience points!")
			fmt.Println("    > (NOTE: You will gain 30% extra experience upon finishing a quest, but will not gain any experience until the end.)")
			time.Sleep(3 * time.Second)
			fmt.Println("\nYou leave the safety and comfort of home to slay the monsters...")
			time.Sleep(2 * time.Second)
			for i := 0; i < battles; i++ {
				fmt.Println("\n " + Descriptions[random(len(Descriptions))])
				time.Sleep(3 * time.Second)

				monster := new(unit)
				if get_level(player) < 10 { // Beginner encounter until level >= 10
					monster.Name = "Practice Dummy"
					monster.Health = 3
					monster.Attack = 1
					monster.Experience = 51
				} else if get_level(player) >= 10 && get_level(player) < 25 { // Easy Encounter
					monster.Name = WeakMonsterName[random(len(WeakMonsterName))]
					monster.Health = random(5) + get_level(player) - 2
					monster.Attack = random(4) + get_level(player)/5
					monster.Defense = random(3)
					monster.Experience = random(50) + 15
				} else if get_level(player) >= 25 && get_level(player) < 80 { // Normal Encounter
					monster.Name = NormMonsterName[random(len(NormMonsterName))]
					monster.Health = random(35) + 20
					monster.Attack = random(20) + 8
					monster.Defense = random(10) + 3
					monster.Experience = random(175) + 79
				} else if get_level(player) >= 80 && get_level(player) < 200 { // Hard Encounter
                                	monster.Name = StrongMonsterName[random(len(StrongMonsterName))]
                                	monster.Health = random(player.Attack*4) + 30
                                	monster.Attack = random(player.Defense*2) + 16
                                	monster.Defense = random(get_level(player)/15 + 4)
                                	monster.Experience = random(325) + 105
                        	}

				player.Health = battle(player, monster)

				if player.Health <= 0 {
					fmt.Println("You died while trying to finish your quest. Loading from last save point...")
					break
				}
				gains += monster.Experience
				fmt.Println("\n You killed the monster! You continue your quest...\n")
			}
			if player.Health > 0 {
				fmt.Println("You finally make it back to " + place + " and find " + person + ". They congratulate you, and you feel a surge of experience being gained.")
				fmt.Println("\n    You gained " + strconv.Itoa(int(float64(player.Experience)+(float64(gains)*1.3))) + " experience!")
				player.Experience = player.Experience + int(float64(gains)*1.3)
			}

		case "5":
			f, err := os.Create(player.Name)
			if err != nil {
				fmt.Println(err)
				return
			}
			l, err := f.WriteString(player.Name + "," +
				strconv.Itoa(player.MaxHealth) + "," +
				strconv.Itoa(player.Health) + "," +
				strconv.Itoa(player.Attack) + "," +
				strconv.Itoa(player.Defense) + "," +
				strconv.Itoa(player.Experience) + "," +
				strconv.Itoa(player.wepBonus) + "," +
				strconv.Itoa(player.armBonus) + ",")
			if err != nil {
				fmt.Println(err)
				f.Close()
				return
			}
			fmt.Println(l, "bytes written. "+player.Name+" saved successfully! To load, enter the same name next time you play!")
			err = f.Close()
			if err != nil {
				fmt.Println(err)
				return
			}

		default:
			fmt.Println("\nInvalid input\n")
		}
	}
}

