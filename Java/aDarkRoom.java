import java.util.Scanner;
import java.util.Random;

public class aDarkRoom
{
   
   public static void main (String[] args)
   {
      Scanner in = new Scanner (System.in);
      Random rand = new Random();
      String password = "1";
      String input = "";
      boolean light = false;
      boolean escape = false;
      boolean brokenLock = true;
      boolean brokenTable = false;
      boolean boxOpened = false;
      
      for (int i = 0; i < 5; ++i) // set the password
      {
         password = password + Integer.toString(rand.nextInt(9)); // add the next digit of the password
      }
      
      System.out.println("INSTRUCTIONS FOR A DARK ROOM");
      System.out.println("There are certain commands you can use in this game. Here's a list. Replace [word] with whatever you want to interact with (do not include [])\r");
      System.out.println("Pull [object]\rhit [object]\rrepair [object]\rtest password (It will then ask you to enter the password you want to test)\rexamine [object]\ropen [object]\rhelp\r");
      System.out.println("Your objective is to find the password and escape the room.\r");
      System.out.println("Welcome to A Dark Room\r");
      System.out.println("It's pitch black. You can't see a thing. You feel a string against your face.\r");
      
      while (light == false) // wait for them to pull the string
      {
         System.out.print("Action: ");
         input = in.nextLine();
         
         if (input.equalsIgnoreCase("pull string")) //if they pull the string
         {
            System.out.println();
            System.out.println("You grab the string and give it a firm tug. A light just above you flicks on, and the string snaps off into your hand.");
            System.out.println("You look around the room and see a wooden table directly in front of you. You're in a metal box, and it looks like the");
            System.out.println("only way out is through a closed door behind you.\r");
            light = true;
         }
         
         else // if they don't pull the string, reset
         {
            System.out.println();
            System.out.println("You can't see anything! You can't do that!\rYou feel a string against your face.\r");
         }
      } // the light is on!
      
      // beneath table is a box attached on, break the table, open the box, find the password, examine door, repair lock with string, try password, and win
      while (escape == false)
      {  //display information about room
          System.out.println();
         
         if (brokenLock) // string
         System.out.println("You have a string in your hand.");
         
         if (brokenTable == false) // table
            System.out.println("A table is in the middle of the room.");
         else
            System.out.println("A table lays broken in the middle of the room. A box that was attached to the bottom of the table is on the floor.");
            
         if (boxOpened && brokenTable) // box
            System.out.println("The box is open. The paper inside the box says: " + password);
            
         System.out.println("A door is behind you.");
         
         // actions
                     /*
                     table
                        - Examine - an old, delicate table
                        - hit - break the table
                        - repair - try to fix, can't
                     */
         System.out.print("Action: ");
         input = in.nextLine();
          
         if (input.equalsIgnoreCase("Examine table") && brokenTable == false) // Table inputs
            System.out.println("It's an old delicate table. It looks pretty fragile. There seems to be a box stuck to the bottom of the table.\rYou try moving the box, but nothing happens.");
         
         else if (input.equalsIgnoreCase("examine table"))
            System.out.println("The table is split in half.");
         
         else if (input.equalsIgnoreCase("hit table") && brokenTable == false)
         {
            brokenTable = true;
            System.out.println("You hit the table as hard as you can, and it splits in half. The box on the bottom of it clatters to the floor,\rand the table is broken into two pieces.");
         }
         
         else if (input.equalsIgnoreCase("repair table") && brokenTable == true)
            System.out.println("You try to repair the broken table, but it cannot be fixed.");
            
                     /*
                     box
                        - Examine - a box. it looks like you could open it
                        - Open - give password
                        - hit - nothing happens
                     */
         else if (input.equalsIgnoreCase("examine box")) // box inputs
            System.out.println("It's a wooden box. It seems to be hollow, and it looks like there's a lid on it. Hinges are attached to the lid.");
            
         else if (input.equalsIgnoreCase("hit box"))
            System.out.println("You hit the box, and the lid pops open shortly before shutting again.");
            
         else if (input.equalsIgnoreCase("open box"))
         {
            System.out.println("You grab the box and open it. There's a scrap of paper with " + password + " written on it.");
            boxOpened = true;
         }
         
         else if (input.equalsIgnoreCase("help"))
            System.out.println("\rCommands\rPull [object]\rhit [object]\rrepair [object]\rtest password (It will then ask you to enter the password you want to test)\rexamine [object]\ropen [object]\rhelp\r");
         
         
               /* Door
                     - Examine -- a metal door. has keypad, lock is broken
                     - test password -- opens door if correct, if wrong, nothing
                     - repair - uses string to repair lock
                     - hit - echos
                     */
         else if (input.equalsIgnoreCase("examine door") && brokenLock == true) // door inputs
            System.out.println("It's a metal door. It looks like it has a keypad to the right. Upon further inspection, you see\rthat the lock is broke. It looks like if you could repair it with something to hold\r it together, it would function correctly.");
         
         // OPEN DOOR OUTPUT
         else if (input.equalsIgnoreCase("open door"))
            System.out.println("You push on the door. It seems to be locked.");
         
         else if (input.equalsIgnoreCase("examine door") && brokenLock == false)
            System.out.println("It's a metal door. It looks like it has a keypad to the right. You fixed the lock with your string,\rso now you should be able to open it with the code.");
         
         else if (input.equalsIgnoreCase("hit door"))
            System.out.println("You slam your fist into the door, and your knuckles instantly throb with pain. A loud echo goes around/rthe room.");
            
         else if (input.equalsIgnoreCase("repair door") && brokenLock == true)
         {
            System.out.println("You take the string from the light and repair the lock with it.");
            brokenLock = false;
            }
            
         else if (input.equalsIgnoreCase("repair door") && brokenLock == false)
            System.out.println("You already repaired the door lock!");
            
         else if (input.equalsIgnoreCase("test password"))
         {
            System.out.print("Password: ");
            input = in.nextLine();
            if (input.equals(password) && brokenLock == false)
            {
               escape = true;
            }
            else if (input == password && brokenLock == true)
            System.out.println("As you enter the last digit of the password, you hear something grind, pause, then grind back. It sounds\rlike it came from the lock on the door.\rThe door is still locked.");
            
            else
               System.out.println("The password is incorrect");
         }
         
         else
         {
            System.out.println("You can't do that / invalid input");
         }
      }// You've escaped!
      
      System.out.println("You enter the code, and you hear the lock twist. You push open the door, and are greeted by light outside the box.");
      System.out.println("You won! Congratulations!");
      
   }

}