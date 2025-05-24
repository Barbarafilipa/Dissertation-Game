É hora de jantar, e os teus pais preparam um prato diferente. #portrait:narration #animation:Child_smiling #animation:Mother_happy #show:Prato #audio:narrator_lvl2_01
Quando olhas para a comida sentes um desconforto na barriga e vontade de vomitar... #animation:Child_disgusted #animation:Mother_serious #audio:narrator_lvl2_02

-> minigame_puzzle_nojo

=== continue1 ===
Parabéns, reconheceste o nojo! O nojo aparece quando algo parece estranho ou nos faz sentir desconfortáveis, como um cheiro mau. #portrait:narration #hide:Prato #sticker:Nojo #show:Nojo #audio:narrator_lvl2_03

Experimenta! #portrait:speech_right #animation:Mother_smiling #hide:Nojo #audio:mother_lvl2_01

+ [Tenho vontade de vomitar, que nojo! $audio:child_lvl2_01]

    Tenho vontade de vomitar, que nojo! #portrait:speech_left #audio:child_lvl2_01
    -> other

+ [Parece estragado, acho que não devia comer isso! $audio:child_lvl2_02]

    Parece estragado, acho que não devia comer isso! #portrait:speech_left #audio:child_lvl2_02
    -> other
    
=== other ===
Tens razão, acho que esta comida não está boa. #portrait:speech_right #audio:mother_lvl2_02

O nojo estava a tentar proteger-te. #audio:mother_lvl2_03

Ele ajuda-nos a afastar coisas que podem fazer-nos mal, como comida estragada. #audio:mother_lvl2_04

-> main

=== main ===

Tens aqui um prato novo. #portrait:speech_right #audio:mother_lvl2_05

Experimenta para veres se gostas, faz bem à saúde. #audio:mother_lvl2_06

Será que quero experimentar? #portrait:thought #animation:Child_serious #audio:child_lvl2_03

+ [Não! Isso é nojento! $audio:child_lvl2_04]

    Não! Isso é nojento! #portrait:speech_left #animation:Child_verydisgusted #animation:Mother_serious #audio:child_lvl2_04
    
    Quando vemos algo estragado, que cheira ou sabe mal, sentimos nojo. #portrait:speech_right #audio:mother_lvl2_07
    
    É uma forma de nos mantermos seguros e saudáveis. #audio:mother_lvl2_08
    
    Mas às vezes, sentimos nojo só porque uma comida é nova ou diferente. #audio:mother_lvl2_09
    
    Isso não quer dizer que esteja estragado. #audio:mother_lvl2_10
    
    Podemos experimentar e ver se gostamos. #animation:Mother_smiling #audio:mother_lvl2_11
    -> main
    
+ [Até posso provar, mas enquanto como vou pensar que estou a comer outra coisa que gosto. $audio:child_lvl2_05]

    Até posso provar, mas enquanto como vou pensar que estou a comer outra coisa que gosto. #portrait:speech_left #animation:Child_serious #animation:Mother_serious #audio:child_lvl2_05
    
    Pensar noutra comida não vai mudar o sabor. #portrait:speech_right #audio:mother_lvl2_12
    Mas se pensares no que cada legume faz de bom vai ser mais fácil experimentar! #animation:Mother_smiling #audio:mother_lvl2_13
    A cenoura ajuda na visão, e os brócolos são ótimos para dar força aos ossos e para a saúde. #audio:mother_lvl2_14
    -> main
    
+ [Se faz bem à saúde, eu posso tentar comer um pedaço. $audio:child_lvl2_06]

    Se faz bem à saúde, eu posso tentar comer um pedaço. #portrait:speech_left #animation:Child_smiling #audio:child_lvl2_06
    
    Boa! Vais ver que vais gostar! Consegues adivinhar o que tem? #portrait:speech_right #animation:Mother_happy #audio:mother_lvl2_15
    -> minigame_prato_misterioso

=== continue2 ===
Parabéns! Aprendeste a reconhecer os ingredientes no teu prato e a experimentar novos sabores. Estás no caminho certo para ser um verdadeiro chef! #portrait:narration #animation:Mother_happy #sticker:ChefDeCozinha #show:ChefDeCozinha #audio:narrator_lvl2_04

Vês? Experimentar não foi assim tão mau! #portrait:speech_right #animation:Mother_smiling #hide:ChefDeCozinha #audio:mother_lvl2_16

Ainda não adoro, mas consegui comer um pouco. #portrait:speech_left #audio:child_lvl2_07

E isso já é um grande passo. O teu paladar pode mudar com o tempo! #portrait:speech_right #audio:mother_lvl2_17

Explorar novos sabores é uma aventura! Mesmo que ainda não adores, sabes que esses alimentos fazem bem à tua saúde e vão ajudar-te a ser ainda mais forte e saudável. #portrait:narration #sticker:ExploradorDeSabores #show:ExploradorDeSabores #audio:narrator_lvl2_05

-> END

=== minigame_puzzle_nojo ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleNojo
-> continue1

=== minigame_prato_misterioso ===
Minijogo Prato Misterioso #minigame:PratoMisterioso
-> continue2
