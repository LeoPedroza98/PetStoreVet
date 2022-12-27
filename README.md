# Introdução
 Pet Friends é uma rede de lojas franqueadas dedicada aos donos dos aproximadamente 139 milhões de animais de estimação que existem no Brasil.
 Trata-se de uma aplicação WEB-Mobile composta por duas principais frentes de negócios: venda de produtos e prestação de serviços.
 
## **Domínio do sistema proposto e especificação das entidades do domínio:**

#### Clientes 
#### Produtos 
#### Loja 
#### Assinaturas 
#### Pedidos 
#### Pagamentos

**Veterinário** : 
  O objetivo do  micro serviço de veterinário é uma pequena aplicação que oferece serviços específicos como o cadastro do veterinário. Ele pode ser usado como parte de um sistema maior de gerenciamento de clínicas veterinárias ou como uma solução autônoma.
À aplicação foi desenvolvida seguindo as características DDD(Domain Drive Design) foi implementado o IdentityServer provido pela framework Duende Software.




# **Building Blocks**:

![image](https://user-images.githubusercontent.com/49344443/209658417-11dfd55d-4dd5-4fc0-b695-83eb214f460c.png)

**Entidade Veterinário**:
Entidade principal responsável por ser base de todo o CRUD do Micro Serviço.

**Entidade Usuário**:
Entidade responsável por ser à base para IdentityServer criar a Autenticação no micro serviço.





# **Objeto de valor**:

**Especialidade**:
Entidade de objeto de valor auxiliar ao veterinário.

**Contato**:
Entidade de objeto de valor auxiliar ao veterinário.

**Endereço**:
Entidade de objeto de valor auxiliar ao veterinário.

# **Repositórios**:

#### VeterinarioRepository

#### EspecialidadeRepository

# **Services**:

#### LoginService

#### UsuarioService

#### VeterinarioService

#### EspecialidadeService


# **Consultas (Queries)**: 

### Especialidades:

#### Buscar todas as Especialidades

#### Buscar especialidades por Id 

### Veterinários

#### Buscar todos os Veterinários

#### Buscar veterinários por Id

# **Eventos de Domínio (Domain Events)**:

#### Autenticação usuário

#### Criar Veterinário

#### Editar Veterinário

#### Excluir Veterinário


# **Dependências do projeto**:
```
"AutoMapper"
Version="12.0.0"
"AutoMapper.Extensions.Microsoft.DependencyInjection" 
Version="12.0.0"
"Microsoft.AspNetCore.Authentication.JwtBearer" Version="6.0.8"
"Microsoft.AspNetCore.Identity" 
Version="2.2.0" 
"Microsoft.AspNetCore.Identity.EntityFrameworkCore" 
Version="6.0.8"
"Microsoft.AspNetCore.JsonPatch" Version="6.0.2"
"Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="6.0.2"
"Microsoft.AspNetCore.OData" 
Version="8.0.12"
"Microsoft.EntityFrameworkCore" 
Version="6.0.8" 
"Microsoft.EntityFrameworkCore.Design" Version="6.0.8"
"Microsoft.EntityFrameworkCore.Tools" Version="6.0.8"
"Microsoft.Extensions.Identity.Stores" Version="6.0.8"
"Microsoft.Extensions.Logging.Debug" Version="6.0.0"
"Microsoft.VisualStudio.Web.CodeGeneration.Design" 
Version="6.0.2"
"Newtonsoft.Json" 
Version="13.0.2"
"Pomelo.EntityFrameworkCore.MySql" Version="6.0.2"
"Pomelo.EntityFrameworkCore.MySql.Design" Version="1.1.2"
"RabbitMQ.Client" Version="6.4.0"
"Swashbuckle.AspNetCore" Version="6.4.0"
"Swashbuckle.AspNetCore.Annotations" Version="6.4.0"
"Swashbuckle.AspNetCore.Swagger" Version="6.4.0"
"Swashbuckle.AspNetCore.SwaggerGen" Version="6.4.0"
"Swashbuckle.AspNetCore.SwaggerUI" Version="6.4.0"
"System.IdentityModel.Tokens.Jwt" Version="6.25.1"
```

# **Funcionamento e Configuração basica da API**:
* Você deverá possuir o MySQL instalado.

* Para mudar a senha ,usuário, host e porta de acesso ao banco basta ir para o arquivo "appsettings.json" dentro da pasta "API" e mudar os valores de conexão.

* Feito a mudança na conexão com o banco, basta selecionar no topo do VisualStudio no botão da execução a opção "PetStore.VeterinarioAPI" feito a mudança apenas execute o projeto que automaticamente será criado a "Database" no MySQL.


**Observações toda a descrição dos endpoints é melhor detalhado no arquivo incluído no repositório**: “PetStoreVet.postman_collection.json”

# **Repositórios**:

https://github.com/LeoPedroza98/PetStoreVet

https://github.com/LeoPedroza98/PetStoreVet-deployment
