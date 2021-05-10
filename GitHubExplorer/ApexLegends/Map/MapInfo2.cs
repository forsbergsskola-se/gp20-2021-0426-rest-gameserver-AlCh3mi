using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitHubExplorer.ApexLegends.Map {
    public class MapInfo2 {
        Dictionary<string, GameMode> Modes;

        public MapInfo2(string serverResponse) {
            Modes = JsonConvert.DeserializeObject<Dictionary<string, GameMode>>(serverResponse);
        }

        public override string ToString() {
            var response = string.Empty;
            foreach (var mode in Modes) {
                response += mode.ToString();
            }

            return response;
        }

        public void NavigateWithConsole() {
            Console.WriteLine("MapInfo Console Explorer");
            var quit = false;
            do {
                Console.WriteLine();
                Console.WriteLine($"1: {GameMode.BattleRoyale}");
                Console.WriteLine($"2: {GameMode.Arenas}");
                Console.WriteLine($"3: {GameMode.Ranked}");
                Console.WriteLine("Anything else to quit.");
                if (int.TryParse(Console.ReadLine(), out var modeInt)) {
                    switch (modeInt) {
                        case 1: //Display Battle Royale Info
                            Console.WriteLine("Battle Royale:");
                            MapExplorer(Modes[GameMode.BattleRoyale]);
                            break;
                        case 2: //Display Arenas Info
                            Console.WriteLine("Arena's:");
                            MapExplorer(Modes[GameMode.Arenas]);
                            break;
                        case 3:
                            Console.WriteLine("Ranked:");
                            Console.WriteLine($"{Modes[GameMode.Ranked]}");
                            break;
                        default:
                            Console.WriteLine("Invalid option, Quitting.");
                            quit = true;
                            break;
                    }
                }
            } while (!quit);
        }

        void MapExplorer(GameMode mode) {
            while (true) {
                Console.WriteLine("\n1. Current");
                Console.WriteLine("2. Next");
                Console.WriteLine();
                Console.WriteLine("anything else to return.");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out var input)) {
                    if (input == 1)
                        ConsoleMapInfo(mode.Current);
                    else if (input == 2)
                        ConsoleMapInfo(mode.Next);
                    else {
                        Console.WriteLine("Invalid Entry. returning..");                                        
                        break;
                    }
                }
                else Console.WriteLine("Invalid Entry. Please try again.");
            }
        }
        
        void ConsoleMapInfo(Map map) {
            Console.WriteLine($"Current         : {map.Name}");
            Console.WriteLine($"Start           : {map.ReadableDateStart}");
            Console.WriteLine($"End             : {map.ReadableDateEnd}");
            Console.WriteLine($"Duration        : {map.DurationInMinutes}");
            Console.WriteLine($"Mins Remaining  : {map.RemainingMins}");
        }
    }

    public class GameMode {
        public Map Current;
        public Map Next;

        public const string BattleRoyale = "battle_royale";
        public const string Arenas = "arenas";
        public const string Ranked = "ranked";

        public override string ToString() => $"Current: {Current} Next: {Next}";
    }

    public class Map {
        [JsonProperty("readableDate_start")]
        public DateTime ReadableDateStart { get; private set; }

        [JsonProperty("readableDate_end")]
        public DateTime ReadableDateEnd { get; private set; }

        [JsonProperty("map")]
        public string Name { get; private set; }

        [JsonProperty("DurationInMinutes")]
        public int DurationInMinutes { get; private set; }

        [JsonProperty("remainingMins")]
        public int RemainingMins { get; private set; }

        public override string ToString() => Name;
    }
}