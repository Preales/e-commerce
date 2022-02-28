## **E-Commerce .Net 5**
Bienvenido al repositorio de una WebAPI para la simulación pago y creación de pedido de un comercio electrónico, creado con el framework **NET 5.0** y arquitectura **DDD.**
### **Estructura del proyecto**
#### ![](https://github.com/Preales/e-commerce/blob/main/docs/images/1.png)

### **Librerías**
- **Automapper**: herramienta que permite realizar un mapeo de un objeto a otro.
- **FluentValidation:** biblioteca para crear reglas de validación.
- **EntityFrameworkCore:** ORM - Tecnología que permite el acceso a datos por medio de código.
- **Swagger:** herramienta para documentar y consumir servicios web RESTfull.

### **Database**
 **SQL Server**
- Al ejecutar el proyecto se creará la base de datos, las tablas y datos semillas, creador por medio de migraciones
> La migración incluye 3 clientes, 3 productos y un dato de envío por cada cliente
### **Diagrama de entidades**
![](https://github.com/Preales/e-commerce/blob/main/docs/images/2.png)

### **API RESTful**
Por cada una de las entidades, tenemos las siguientes operaciones:

- **POST:** Operación para crear.
- **PUT:** Operación para actualizar
- **GET:**  Operación para obtener un listado datos o para buscar un dato por un Id especifico
- **DELETE:** Operación eliminar física o lógicamente un dato.

![](https://github.com/Preales/e-commerce/blob/main/docs/images/3.png)

![](https://github.com/Preales/e-commerce/blob/main/docs/images/4.png)

![](https://github.com/Preales/e-commerce/blob/main/docs/images/5.png)

![](https://github.com/Preales/e-commerce/blob/main/docs/images/6.png)

El servicio de Order tiene un endpoint en particular, el cual es **GetByIdInclude,** el cual retorna la información del pedido a buscar y toda su información de detalle, cliente e información de envío.

![](https://github.com/Preales/e-commerce/blob/main/docs/images/7.png)

### **Modo de uso**
Para realizar las operaciones de sumatoria de los productos y generar un pedido, debemos usar el endpoint de **Payments** esta operación recibe cómo cuerpo la siguiente información en tipo json.

![](https://github.com/Preales/e-commerce/blob/main/docs/images/8.png)


### **Ejemplo**

Este es un objeto para crear un pedido
```sh
{
  "clientId": "1234561",
  "shippingId": "b7fc1742-3c68-4630-a2f6-a1f7c0007a2f",
  "orderDetails": [
    {
      "productId": 2,
      "price": 5466,
      "tax": 19,
      "quantity": 1,
      "discount": 100
    },
{
      "productId": 3,
      "price": 5379,
      "tax": 7,
      "quantity": 2,
      "discount": 30
    }
  ]
}
```
Para realizar pruebas online, puede ingresar al siguiente link [E-Commerce](http://ecommerce-preales.azurewebsites.net/swagger/index.html)
La aplicación esta desplegada en un AppService de Azure y usa Azure SQL Database
