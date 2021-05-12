﻿public class Station {
    public string id { get; set; }
    public string name { get; set; }
    public float x { get; set; }
    public float y { get; set; }
    public int bikesAvailable { get; set; }
    public int spacesAvailable { get; set; }
    public int capacity { get; set; }
    public bool allowDropoff { get; set; }
    public bool allowOverloading { get; set; }
    public bool isFloatingBike { get; set; }
    public bool isCarStation { get; set; }
    public string state { get; set; }
    public string[] networks { get; set; }
    public string realTimeData { get; set; }

    public override string ToString() {
        return $"{name} {state}[{id}]:\n" +
               $"Bikes Available: {bikesAvailable}\n" +
               $"{spacesAvailable} / {capacity}";
    }
}