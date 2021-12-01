using TO_Lab_4;

using var window = new SingleWindow(
    new Simulation(
        new Population(500, 10, 10, 25, 4, 50),
        100
    )
);

window.Run(25, 144);