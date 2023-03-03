# RunnerTools

A aplicação pretende auxiliar corredores no planeamento e análise de treinos.

Deverá permitir a realização de cálculos básicos de conversão e cálculos de ritmo para diferentes tipos de treino.

Deverá obter informação, em outras plataformas, de treinos realizados. Essas informações deverão ficar armazenadas para possibilitar seu uso em comparações e estatísticas.

Deverá utilizar autenticação para que permita armazenamento de dados por utilizador e para que possa vincular cada utilizador com seu utilizador de outras plataformas.

## Cálculos básicos

Possivelmente para uso sem autenticação, deverá fornecer os seguintes cálculos:

1. Conversão de velocidade (km/h) para ritmo (min/km) e vice-versa
   - Exemplo: 10,00 km/h -> 10,00/60 min -> 6,00 min/km
   - Exemplo: 6,00 min/km -> 60,00/10 km -> 10,00 km/h
   
2. Cálculo de ritmo (dada distância e tempo desejados)
   - Exemplo: 10 km em 50 minutos -> 5 min/km
   
3. Cálculo de velocidade (dada uma distância e tempo desejados)
   - Exemplo: 10 km em 50 minutos -> 12 min/km
   
4. Cálculo de tempo (dados ritmo e distância desejados)
   - Exemplo: 21,097 km (meia maratona) com ritmo de 5:30 min/km -> 1:56:02

## Cálculos de treinos

Para utilizadores autenticados, deverá permitir:

- Calcular ritmos para tipos de treino diferentes (Ritmo, Regenerativo, Progressivo, Fartlek e, possivelmente, Tiros)
- Vincular conta com outras plataformas (lista abaixo)
- Obter informações de treinos de outras plataformas (atenção para treinos repetidos em plataformas diferentes)
- Enviar para outras plataformas o treino criado
- Permitir comparar treino planeado com executado
  - Permitir gravar comparativo, com adição de outras informações (observações, etc)

## Funcionalidades adicionais

- Exportar plano de treino (descarregar ficheiro)
- Exportar treino para outras plataformas (lista abaixo)
 
## Plataformas de interesse

- [Garmin](https://developer.garmin.com/fit/overview/)
- [Suunto](https://apizone.suunto.com/docs/services/)
- [Polar](https://www.polar.com/accesslink-api/#polar-accesslink-api)
- [Google Fit](https://developers.google.com/fit/rest?hl=pt-br)
- [Runkeeper](https://runkeeper.com/developer/healthgraph) (restrito à parceiros - [StackOverflow](https://stackoverflow.com/questions/62769836/runkeeper-health-graph-api-documentation))
- Nike Run
- [MapMyRun](https://developer.underarmour.com/docs/)

## Perfis de utilizador

De partida haverá apenas 1 perfil de utilizador, para que seja possível autenticar na aplicação.

No entanto, podemos adicionar recursos Premium e autorizar consoante perfil/perfis de utilizador Premium.

## Modelos de utilização

Será preciso definir/escolher o modelo de utilização e perfis entre os 4 possíveis modelos identificados abaixo.

1. Com recursos básicos sem autenticação e sem recursos Premium (recursos avançados = recursos premium)

   |                 | Recursos básicos | Recursos avançados |
   | --------------- | :--------------: | :----------------: |
   | **Visitante**   |     &#10004;     |      &#10006;      |
   | **Autenticado** |     &#10004;     |      &#10004;      |

2. Com recursos básicos sem autenticação e com recursos Premium diferenciados (recursos avançados != recursos premium)

   |                           | Recursos básicos | Recursos avançados | Recursos Premium |
   | ------------------------- | :--------------: | :----------------: | :--------------: |
   | **Visitante**             |     &#10004;     |      &#10006;      |     &#10006;     |
   | **Autenticado**           |     &#10004;     |      &#10004;      |     &#10006;     |
   | **Assinante autenticado** |     &#10004;     |      &#10004;      |     &#10004;     |

3. Com todos os recursos apenas para utilizadores autenticados e sem recursos Premium (recursos avançados = recursos premium)

   |                 | Recursos básicos | Recursos avançados |
   | --------------- | :--------------: | :----------------: |
   | **Visitante**   |     &#10006;     |      &#10006;      |
   | **Autenticado** |     &#10004;     |      &#10004;      |

4. Com todos os recursos apenas para utilizadores autenticados e com recursos Premium diferenciados (recursos avançados != recursos premium)

   |                           | Recursos básicos | Recursos avançados | Recursos Premium |
   | ------------------------- | :--------------: | :----------------: | :--------------: |
   | **Visitante**             |     &#10006;     |      &#10006;      |     &#10006;     |
   | **Autenticado**           |     &#10004;     |      &#10004;      |     &#10006;     |
   | **Assinante autenticado** |     &#10004;     |      &#10004;      |     &#10004;     |
