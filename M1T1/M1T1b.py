import os
from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes

backend = default_backend()
key = bytes(str('12345678901234567890123456789012'), 'ascii')  # Clave
iv = os.urandom(16)  # Vector inizialicion
cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=backend)
encryptor = cipher.encryptor()
cryptogram = encryptor.update(b"a secret message") + encryptor.finalize()
print('Cifrado modo CBC:', cryptogram)

decryptor = cipher.decryptor()
cleartText = decryptor.update(cryptogram) + decryptor.finalize()
print('Texto claro: ', cleartText)

