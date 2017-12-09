/*
ФИО: Костюченко Илья Игоревич
Группа: БПИ 171-1
Дата: 21.11.2017
Вариант: m2.2.4
*/

using System;
using static Iko.Iko;
using System.Linq;
using static System.Console;

namespace SR2 {
    class Meetings {
        /// <summary>
        /// Each element represents the number of dates a person has in a given day.
        /// </summary>
        int[] days;

        /// <summary>
        /// The total number of days allocated for the task.
        /// </summary>
        /// <value>The total number of days.</value>
        public int TotalDays => days.Length;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SR2.Meetings"/> class.
        /// </summary>
        /// <param name="totalDays">the total number of days allocated.</param>
        public Meetings(int totalDays) {
            days = new int[totalDays];
        }

        /// <summary>
        /// Gets or sets the number of date in a given day. Throws an exception if passed an invalid index.
        /// </summary>
        /// <param name="dayNumber">Day number.</param>
        public int this[int dayNumber] {
            get {
                return days[dayNumber];
            }
            set {
                days[dayNumber] = value;
            }
        }  

        /// <summary>
        /// A random number generator.
        /// </summary>
        static readonly Random rand = new Random();

        /// <summary>
        /// Gets the total number of tries.
        /// </summary>
        /// <value>The total number of tries.</value>
        public int TotalNumberOfTries {
            get {
                return days.Sum();
            }
        }

        /// <summary>
        /// Checks whether Petya is happy with the outcome of his endeavor.
        /// </summary>
        /// <returns><c>true</c>, if petya is happy, <c>false</c> otherwise.</returns>
        public bool IsPetyaHappy() {
            var sum = TotalNumberOfTries;
            for (var i = 0; i < sum; i++) {
                if (rand.Next(10) == 0) {
                    return true;
                }
            }
            return false;
        }
    }

    class MainClass {
        public static void Main(string[] args) {
            var rand = new Random();
            Repeat(() => {
                var meets = new Meetings(rand.Next(1, 21));
                for (var i = 0; i < meets.TotalDays; i++) {
                    meets[i] = rand.Next(4);
                }
                WriteLine($"Petya allocated {meets.TotalDays} days");
                WriteLine($"Petya has made {meets.TotalNumberOfTries} meetings");
                WriteLine("Petya is " + (meets.IsPetyaHappy() ? "happy" : "unhappy"));
            });
        }
    }
}
