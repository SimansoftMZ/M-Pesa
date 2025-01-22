# M-Pesa

**Descrição:** Este projeto é uma API Restful para integração com o M-pesa, com foco na simplicidade e flexibilidade. Ele é desenvolvido em .NET usando a versão mais recente e será hospedado no Azure. Além disso, estamos criando um pacote NuGet para facilitar a instalação e uso.

## Funcionalidades
- [x] Autenticação com M-pesa
- [ ] Consulta de saldo
- [ ] Envio de dinheiro
- [ ] Recebimento de dinheiro
- [ ] Notificações em tempo real

## Pré-requisitos
- .NET SDK (versão 8.0.0)
- Conta no Azure
- Chave de API do M-pesa

## Instalação
1. Clone este repositório.
2. Abra o projeto no Visual Studio ou Visual Studio Code.
3. Configure suas credenciais do M-pesa no arquivo `appsettings.json`.
4. Execute o projeto.

## Uso
1. Faça uma chamada à API para autenticar e obter um token de acesso.
2. Use os endpoints disponíveis para consultar saldo, enviar ou receber dinheiro.

## Contribuição
Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request.

# Estratégia de Ramificação Gitflow
Este projeto segue a estratégia de ramificação Gitflow, que é uma abordagem estruturada para o gerenciamento de versões. Abaixo está a sequência de branches que usamos:

1. **Branch `feature`**: Criação e desenvolvimento de novas funcionalidades.
2. **Branch `develop`**: Integração das funcionalidades e preparação para o próximo lançamento.
3. **Branch `release`**: Ajustes finais e preparação para o lançamento da versão.
4. **Branch `main`**: Versão estável do software, pronta para produção.

## Fluxo de Trabalho
- **Feature ➡️ Develop**: Funcionalidades são desenvolvidas em suas próprias branches `feature` e, após a conclusão, são mescladas na branch `develop`.
- **Develop ➡️ Release**: Quando as funcionalidades na branch `develop` estão prontas para lançamento, uma branch `release` é criada para ajustes finais.
- **Release ➡️ Main**: Após a conclusão dos testes e ajustes na branch `release`, o código é mesclado na branch `main` para lançamento.

Lembre-se de que as branches `hotfix` e `bugfix` também são usadas conforme necessário para correções urgentes e regulares, respectivamente.

## Contribuindo
Para contribuir com o projeto, por favor, siga a estratégia de ramificação descrita acima. Isso garante que o processo de desenvolvimento seja suave e organizado.

Para mais informações sobre como contribuir, consulte o guia de contribuição do projeto.

## Licença
Este projeto está licenciado sob a Licença MIT. Consulte o arquivo LICENSE para obter mais detalhes.
