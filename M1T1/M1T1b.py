import os
from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes

backend = default_backend()
clave = bytes(str('12345678901234567890123456789012'), 'ascii')

vectorInicializacion = os.urandom(16)  # Vector inicializacion

textoPlano = bytes("a secret message", 'ascii')
print('Texto claro: ', textoPlano)

#  AES y Output Feedback (OFB)
cipher = Cipher(algorithms.AES(clave), modes.OFB(vectorInicializacion), backend=backend)
encryptor = cipher.encryptor()

criptogramaOFB = encryptor.update(textoPlano) + encryptor.finalize()
print('Cifrado modo OFB:', criptogramaOFB)

#  AES y Cipher Feedback (CFB)
cipher = Cipher(algorithms.AES(clave), modes.CFB(vectorInicializacion), backend=backend)
encryptor = cipher.encryptor()

criptogramaCFB = encryptor.update(textoPlano) + encryptor.finalize()
print('Cifrado modo CFB:', criptogramaCFB)

#  AES y Electronic Code Book (ECB)
cipher = Cipher(algorithms.AES(clave), modes.ECB(), backend=backend)
encryptor = cipher.encryptor()

criptogramaECB = encryptor.update(textoPlano) + encryptor.finalize()
print('Cifrado modo ECB:', criptogramaECB)

assert criptogramaOFB == criptogramaCFB
assert criptogramaOFB != criptogramaECB
assert criptogramaCFB != criptogramaECB

decryptor = cipher.decryptor()
textoDesencriptado = decryptor.update(criptogramaECB) + decryptor.finalize()
print('Texto desencriptado: ', textoDesencriptado)

assert textoPlano == textoDesencriptado
