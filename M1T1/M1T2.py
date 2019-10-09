import os
from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes

backend = default_backend()
clave = bytes(str('12345678901234567890123456789012'), 'ascii')

vectorInicializacion = os.urandom(16)  # Vector inicializacion
#  AES y Cipher Block Chaining (CBC)
cipher = Cipher(algorithms.AES(clave), modes.CBC(vectorInicializacion), backend=backend)
encryptor = cipher.encryptor()

textoPlano = bytes("a secret message", 'ascii')
print('Texto claro: ', textoPlano)
criptograma = encryptor.update(textoPlano) + encryptor.finalize()
print('Cifrado modo CBC:', criptograma)

decryptor = cipher.decryptor()
textoDesencriptado = decryptor.update(criptograma) + decryptor.finalize()
print('Texto desencriptado: ', textoDesencriptado)

assert textoPlano == textoDesencriptado
