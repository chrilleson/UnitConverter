FROM node:16.13.2 as builder

COPY package.json package-lock.json ./
RUN npm i && mkdir /ng-app && mv ./node_modules ./ng-app

WORKDIR /ng-app
COPY . .
RUN $(npm bin)/ng build --output-path=dist

FROM nginx:1.14.1-alpine
COPY nginx.conf /etc/nginx/conf.d/default.conf

RUN rm -rf /usr/share/nginx/html*

COPY --from=builder /ng-app/dist /usr/share/nginx/html

CMD ["nginx", "-g", "daemon off;"]