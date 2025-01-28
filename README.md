Api que pertite en memoria las principales transacciones de un Banco, Crear una cuenta, Revisar el saldo de la cuenta, Realizar Depositos, Realizar Retiros, Revisar las transacciones reliazadas.
Para porbar el proyecto 
1. Crear una cuenta con un saldo inicial de 1,000. EL PRIMER POST  [HttpPost("create")]
 2. Realizar un depósito de 500. (Saldo: 1,500) POST   [HttpPost("{accountNumber}/deposit")]
 3. Intentar un retiro de 2,000. La transacción debe fallar porque no hay fondos suficientes. post  [HttpPost("{accountNumber}/withdraw")] Este se valida en la clase account.
 4. Realizar un retiro de 200. (Saldo: 1,300) post  [HttpPost("{accountNumber}/withdraw")]
 5. Consultar el saldo final. GET  [HttpGet("{accountNumber}")]
 6. obtener un resumen de transacciones. get [HttpGet("{accountNumber}/transactions")]
