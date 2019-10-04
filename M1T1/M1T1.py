from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.backends import default_backend
backend = default_backend()
key=bytes(str('123455789012345678901234'), 'ascii')
cipher = Cipher(algorithms.TripleDES(key), modes.ECB(), backend=backend)
encryptor = cipher.encryptor()
cryptogram = encryptor.update(b"a secret message") + encryptor.finalize()
print(cryptogram)