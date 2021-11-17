package pl.retsuz.shell.variations.mkdir;

import pl.retsuz.filesystem.Composite;
import pl.retsuz.filesystem.IComposite;
import pl.retsuz.shell.gen.ICommand;
import pl.retsuz.shell.variations.gen.CommandVariation;
import pl.retsuz.shell.variations.gen.ICommandVariation;

public class Mkdir_Path extends CommandVariation {
    public Mkdir_Path(ICommandVariation next, ICommand parent) {
        super(next, parent, "[ a-zA-Z0-9.l\\/_]*");
    }

    @Override
    public void make(String params) {

        Composite c = (Composite) (this.getParent().getContext().getCurrent());


        String[] paths = params.split(" ");


        for (String dirPath : paths) {
            try {
                String[] sub_paths = dirPath.split("/");

                Composite c2 = c;


                for (int i = 0; i < sub_paths.length; i++) {
                    String path = sub_paths[i];
                    if (path.equals("..")) {
                        c2 = (Composite) c2.getParent();
                    } else {
                        try {
                            c2 = (Composite) c2.getElement(c2.findElementByPath(path));

                            if (path.equals(sub_paths[sub_paths.length - 1]) && i == sub_paths.length - 1)
                                System.out.println("Dolecowy katalog istnieje");

                        } catch (Exception e) {
                            IComposite new_composite = new Composite();
                            new_composite.setName(path);
                            c2.addElement(new_composite);
                            c2 = (Composite) c2.getElement(c2.findElementByPath(path));
                            System.out.println("Creating " + path);
                        }
                    }
                }
                System.out.println(dirPath);
            } catch (Exception e) {
                System.out.println("Docelowy katalog nie istnieje i nie może zostać utworzony - out of scope.");
            }
        }

    }
}