export function query_login(userName: string, password: string) {
    return `query login {
          login(userName: "${userName}", password: "${password}") {
            id,
            userName,
            elevated
          }
        }`
}