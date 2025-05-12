É hora do intervalo. Estás a jogar à bola com o teu amigo, mas ele empurra-te e fica com a bola. #portrait:narration
Começas a sentir o corpo a aquecer... 

-> minigame_puzzle_raiva

=== continue1 ===
Parabéns, reconheceste a raiva! A raiva aparece quando sentimos que fomos tratados de forma injusta ou quando não conseguimos fazer o que queremos. #portrait:narration

-> main

=== main ===
Isti não é justo! #portrait:thought 

+ [Vou empurrá-lo também!]

    Vou empurrá-lo também! #portrait:speech_left #animation:Friend_serious
    
    Empurrar de volta só te vai deixar com mais raiva. Magoar os outros não resolve o problema e pode deixar os dois tristes. #portrait:narration
    
    O teu amigo pode ficar ainda mais chateado. Vamos tentar resolver isto de outra forma?
    
    -> main
    
+ [Vou brincar com outro amigo.]

    Vou brincar com outro amigo. #portrait:speech_left
    
    Sair sem dizer nada pode fazer o teu amigo pensar que não queres mais brincar com ele.  #portrait:narration
    
    Se explicares como te sentiste pode ser mais fácil resolverem o problema juntos.
    
    -> main
    
+ [Se calhar foi sem querer.]

    Se calhar foi sem querer. #portrait:speech_left
    
    Às vezes as coisas acontecem sem intenção. Pensar assim ajuda-te a acalmar e a resolver melhor o problema. Agora tenta falar com ele com calma. #portrait:narration
    
    -> minigame_reciclagem_da_raiva
    

=== continue2 ===
Parabéns! Aprendeste que, tal como reciclamos o lixo, também podemos reciclar os pensamentos maus e transformar a raiva em algo melhor. #portrait:narration 

Já me sinto melhor. Vou falar com ele. #portrait:speech_left

-> novas_escolhas

=== novas_escolhas ===
Ele já não quer jogar comigo... #portrait:speech_left

Às vezes as coisas não acontecem como esperávamos, e isso pode fazer-nos sentir tristes #portrait:narration

+ [Ele já não gosta de mim, é por isso que não quer jogar comigo...]
    
    Ele já não gosta de mim, é por isso que não quer jogar comigo... #portrait:speech_left
    
    Quando estamos tristes, a nossa cabeça fica a girar só nos mesmos pensamentos. Mas pensar só nas coisas tristes não nos ajuda a entender o que aconteceu. Vamos tentar parar essa roda? #portrait:narration

    -> novas_escolhas

+ [Nunca mais quero falar com ele!]

    Nunca mais quero falar com ele! #portrait:speech_left
    
    Quando estamos tristes, às vezes queremos fugir ou ir embora. Mas isso é como esconder a tristeza debaixo do tapete. #portrait:narration
    
    Pode parecer que está tudo bem, mas o problema não desaparece. Que tal falar com ele sobre como te sentes?

    -> novas_escolhas
    
+ [Vou-lhe dizer que fiquei magoado.]

    Vou-lhe dizer que fiquei magoado. #portrait:speech_left
    
    Falar sobre os sentimentos é uma boa maneira de resolver os problemas. Às vezes os nossos amigos não sabem como nos sentimos. #portrait:narration

    -> minigame_reconstruir_amizade
    
=== continue3 ===

Parabéns! Conseguiste reparar a amizade com o teu amigo. Quando ficamos triste às vezes é difícil falar, mas soubeste expressar os teus sentimentos e ultrapassaste o momento difícil. #portrait:narration 

Ei, eu fiquei triste porque não quiseste jogar comigo. #portrait:speech_left

Está tudo bem, mas queria que soubesses.

Desculpa, não queria magoar-te. #portrait:speech_right

Se quiseres podemos jogar juntos agora.

Com a raiva, aprendeste a pensar antes de agir, e com a tristeza, partilhaste o que sentias. Uma coversa honesta ajudou a resolver tudo e a tornar a amizade mais forte! #portrait:narration

-> END

=== minigame_puzzle_raiva ===
Qual é a emoção que o João está a sentir? #portrait:narration #minigame:PuzzleRaiva
-> continue1

=== minigame_reciclagem_da_raiva ===
Minijogo Reciclagem da Raiva #minigame:ReciclagemdaRaiva
-> continue2

=== minigame_reconstruir_amizade ===
Minijogo Reconstruir a Amizade #minigame:ReconstruirAmizade
-> continue3
