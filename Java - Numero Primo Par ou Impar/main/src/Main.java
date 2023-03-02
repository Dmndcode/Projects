import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        try {
            Scanner leitor = new Scanner(System.in);
            System.out.println("Insira um número: ");
            int numero = 0;
            while (numero < 1) {
                numero = leitor.nextInt();
            }

            boolean primo = true;
            for (int i = 2; i < numero; i++) {
                if (numero % i == 0) {
                    primo = false;
                    break;
                }
            }
            if (primo) {
                System.out.println("Número Primo");
            } else {
                System.out.println("Número composto.");
            }

            int verificar = numero%2;
            if (verificar == 0){
                System.out.println("Número é par");
            }
            else {
                System.out.println("Número é impar");
            }
        }
        catch (Exception e) {
            System.out.println("Falha: " +e.getMessage());
        }
    }
}