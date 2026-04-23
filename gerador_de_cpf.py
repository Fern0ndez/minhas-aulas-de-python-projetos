import random

def gerar_cpf():
    # gera os 9 primeiros dígitos
    cpf = [random.randint(0, 9) for _ in range(9)]

    # calcula o primeiro dígito verificador
    soma = sum((10 - i) * cpf[i] for i in range(9))
    dig1 = (soma * 10 % 11) % 10
    cpf.append(dig1)

    # calcula o segundo dígito verificador
    soma = sum((11 - i) * cpf[i] for i in range(10))
    dig2 = (soma * 10 % 11) % 10
    cpf.append(dig2)

    # transforma em string
    cpf_str = ''.join(map(str, cpf))

    # formata: 000.000.000-00
    return f"{cpf_str[:3]}.{cpf_str[3:6]}.{cpf_str[6:9]}-{cpf_str[9:]}"

# gerar CPF
print("CPF gerado:", gerar_cpf())