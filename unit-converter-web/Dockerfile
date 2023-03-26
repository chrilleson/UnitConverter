## STAGE 1 node ##
FROM node:18.13.0 as builder

# Set base dir
WORKDIR /app
# Copy app files
COPY . .
# Clean npm install
RUN npm ci
# Build the app
RUN npm run build

## STAGE 2 Nginx ##
FROM nginx:1.14.1-alpine
# Copy nginx conf file
COPY nginx.conf /etc/nginx/conf.d/default.conf
# Remove defult nginx page
RUN rm -rf /usr/share/nginx/html/*
# Copy from build step to default nginx app
COPY --from=builder /app/build /usr/share/nginx/html/

CMD [ "nginx", "-g", "daemon off;" ]