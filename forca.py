import os
import getpass

palavra = getpass.getpass("Digite a palavra secreta: ").lower()
os.system("clear")

tamanho = len(palavra)

letras_descobertas = "_" * tamanho
letras_usadas = ""
tentativas = 0
max_tentativas = 6

while tentativas < max_tentativas:

    print("Palavra:", letras_descobertas)
    print("Letras usadas:", letras_usadas)

    letra = input("Digite uma letra: ").lower()

    if letra in letras_usadas:
        print("Você já tentou essa letra")

    else:

        letras_usadas = letras_usadas + letra

        if letra in palavra:

            nova = ""
            i = 0

            while i < tamanho:

                if palavra[i] == letra:
                    nova = nova + letra
                else:
                    nova = nova + letras_descobertas[i]

                i = i + 1

            letras_descobertas = nova

        else:
            tentativas = tentativas + 1
            print("Errado! Tentativas restantes:", max_tentativas - tentativas)

    if tentativas == 0:
        print(" _______")
        print(" |     |")
        print(" |")
        print(" |")
        print(" |")
        print("_|_")

    if tentativas == 1:
        print(" _______")
        print(" |     |")
        print(" |     O")
        print(" |")
        print(" |")
        print("_|_")

    if tentativas == 2:
        print(" _______")
        print(" |     |")
        print(" |     O")
        print(" |     |")
        print(" |")
        print("_|_")

    if tentativas == 3:
        print(" _______")
        print(" |     |")
        print(" |     O")
        print(" |    /|")
        print(" |")
        print("_|_")

    if tentativas == 4:
        print(" _______")
        print(" |     |")
        print(" |     O")
        print(" |    /|\\")
        print(" |")
        print("_|_")

    if tentativas == 5:
        print(" _______")
        print(" |     |")
        print(" |     O")
        print(" |    /|\\")
        print(" |    /")
        print("_|_")

    if tentativas == 6:
        print(" _______")
        print(" |     |")
        print(" |     O")
        print(" |    /|\\")
        print(" |    / \\")
        print("_|_")

    if "_" not in letras_descobertas:
        print("Parabéns! Você acertou:", palavra)
        tentativas = max_tentativas

if "_" in letras_descobertas:
    print("Game Over! A palavra era:", palavra)