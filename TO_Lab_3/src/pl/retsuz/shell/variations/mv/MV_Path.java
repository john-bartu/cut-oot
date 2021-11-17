package pl.retsuz.shell.variations.mv;

import pl.retsuz.filesystem.Composite;
import pl.retsuz.filesystem.IComposite;
import pl.retsuz.shell.gen.ICommand;
import pl.retsuz.shell.variations.gen.CommandVariation;
import pl.retsuz.shell.variations.gen.ICommandVariation;

public class MV_Path extends CommandVariation {
    public MV_Path(ICommandVariation next, ICommand parent) {
        super(next, parent, "[a-zA-Z0-9.l\\/_]* [a-zA-Z0-9.l\\/_]*");
    }

    @Override
    public void make(String params) {

        String[] splits = params.split(" ");


        Composite c = (Composite) (this.getParent().getContext().getCurrent());
        try {
            IComposite compositeElement = null, compositeDestination = null;

            try {
                compositeElement = c.findElementByPath(splits[0]);

                try {
                    compositeDestination = c.findElementByPath(splits[1]);

                    try {
                        Composite.moveElement(compositeElement.getParent(), compositeDestination, compositeElement);
                    } catch (Exception e) {
                        System.out.println("Error during moving");
                        System.out.println(e.getMessage());
                    }

                } catch (Exception e) {
                    System.out.println("Ścieżka docelowa nie instnieje");
                }

            } catch (Exception e) {
                System.out.println("Element przenoszony nie istnieje");
            }

        } catch (Exception e) {
            System.out.println("General MV error");
        }

    }
}