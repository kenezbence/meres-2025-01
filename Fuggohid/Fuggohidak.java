import javax.swing.;
import java.awt.;
import java.awt.event.*;
import java.util.List;
import java.util.stream.Collectors;

public class KeresesForm extends JFrame {
    private JComboBox<String> orszagBox;
    private JTextArea eredmenyText;
    private MainForm mainForm;

    public KeresesForm(MainForm mainForm, List<Fuggohid> hidak) {
        this.mainForm = mainForm;
        setTitle("Keresés");
        setSize(400, 300);
        setDefaultCloseOperation(DISPOSE_ON_CLOSE);
        setLayout(new BorderLayout());

        orszagBox = new JComboBox<>(hidak.stream().map(Fuggohid::getOrszag).distinct().toArray(String[]::new));
        add(orszagBox, BorderLayout.NORTH);

        eredmenyText = new JTextArea();
        add(new JScrollPane(eredmenyText), BorderLayout.CENTER);
        JPanel buttonPanel = new JPanel();
        JButton keresButton = new JButton("Keresés");
        JButton bezarButton = new JButton("Bezárás");

        keresButton.addActionListener(e -> keres(hidak));
        bezarButton.addActionListener(e -> {
            this.dispose();
            mainForm.ujraMegjelenit();
        });

        buttonPanel.add(keresButton);
        buttonPanel.add(bezarButton);
        add(buttonPanel, BorderLayout.SOUTH);

        setVisible(true);
    }

    private void keres(List<Fuggohid> hidak) {
        String orszag = (String) orszagBox.getSelectedItem();
        List<String> eredmenyek = hidak.stream()
                .filter(h -> h.getOrszag().equals(orszag))
                .map(Fuggohid::getNev)
                .collect(Collectors.toList());
        eredmenyText.setText(String.join("\n", eredmenyek));
    }
}