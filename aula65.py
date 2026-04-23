def multiplicar(*args):
    total = 1 
    for numero in args :
        total *= numero
    return total

multiplicação = multiplicar (10, 2 ,3 ,4 , 5)
print(multiplicação)

print("////////////////////////////////////////////////")
def par_impar(numero):
    multiplo_de_dois = numero % 2 == 0

    if multiplo_de_dois:
        return f"{numero} é par"
    else:
        return f"{numero} é ímpar"


print(par_impar(2))
print(par_impar(3))
print(par_impar(15))